using CommunityToolkit.WinForms.AI;
using CommunityToolkit.WinForms.FluentUI.Controls.TypedInputExtenders;
using System.ComponentModel;
using System.Text.Json;

namespace CommunityToolkit.WinForms.FluentUI.Controls.AITypedInputExtenders;

public partial class AIMeasurementFormatterComponent
{
    public class AIMeasurementFormatter : TypedFormatter<Decimal?>
    {
        private const string OpenAiApiKeyLookupKey = "AI:OpenAi:ApiKey";
        private const string DefaultNumberFormat = "#,##0.00";

        private readonly SemanticKernelComponent _skComponent = new();

        protected const string SystemPrompt =
        """
        You are a .NET intelligent decimal input assistant, which task is to convert measurement units/values to a target measurement based on a decimal value.

        * You are given the current value as string, which can contain a measurement unit, and the target measurement unit.
        * Convert the value to the target measurement unit, if possible. Otherwise strip the input of any non-numerical characters 
          (except for the decimal point or thousands separator), and return the value. In that case, set the return status to 'WARNING'
          with a brief description.
        * If the input is a number, but the target unit is not clear, return the number as is, and set the return status to 'WARNING' with a brief description.
        * If the input is not a number, try to make sense of the input "I used the meaning-of-life amount of grams of sugar in my coffee." -> 42.0,
          but issue a WARNING and a brief description.

        * In any case, return in MetaData a brief description of what you did to the input value.

        Please return the corrected text as Json and take the enclosed schema into account.
        """;

        [DefaultValue(null)]
        public string? MetaData { get; set; }

        [DefaultValue(DefaultNumberFormat)]
        public string? NumberFormat { get; set; } = DefaultNumberFormat;

        [DefaultValue(null)]
        public string? TargetUnit { get; set; }

        public override Task<string?> ConvertToDisplayAsync(Decimal? value, CancellationToken token)
        { 
            string? returnValue = value?.ToString(NumberFormat);
            return Task.FromResult<string?>(returnValue);
        }

        public override async Task<Decimal?> ConvertToValueAsync(string? value, CancellationToken token)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            _skComponent.ApiKeyGetter = () => Environment.GetEnvironmentVariable(OpenAiApiKeyLookupKey)
                ?? throw new InvalidOperationException("The AI:OpenAI:ApiKey environment variable is not set.");

            _skComponent.DeveloperPrompt = SystemPrompt;

            _skComponent.JsonSchemaString =
               """
                {
                  "$schema": "http://json-schema.org/draft-07/schema#",
                  "type": "object",
                  "properties": {
                    "DecimalValueAsText": {
                      "type": "string",
                      "description": "The user's input for an amount of a unit, including the unit name."
                    },
                    "MetaData": {
                      "type": "string",
                      "description": "A brief description of what needed to do to get the required Measurement value, which can be parsed as Decimal value."
                    },
                    "ReturnStatus": {
                      "type": "string",
                      "description": "Either 'OK', "WARNING" or "ERROR" - followed by a brief description of what want wrong."
                    }
                  },
                  "required": ["DecimalValueAsText", "MetaData", "ReturnStatus"],
                  "additionalProperties": false
                }
                """;

            string request = $"The target unit is {TargetUnit}\n." +
                $"The user requested assistance for the following Decimal value-based measurement conversion:\n" +
                $"{value}.";

            string? jsonData = await _skComponent.RequestTextPromptResponseAsync(request, false);
            AIDecimalParsingReturnValues? decimalReturnValues = null;

            if (string.IsNullOrEmpty(jsonData))
            {
                throw new InvalidOperationException("Trying to parse the text input failed for unknown reasons.");
            }

            try
            {
                decimalReturnValues = JsonSerializer.Deserialize<AIDecimalParsingReturnValues>(jsonData);

                if (decimalReturnValues is null)
                {
                    throw new InvalidOperationException("Trying to parse the text input failed for unknown reasons.");
                }

                if (decimalReturnValues.ReturnStatus != "OK")
                {
                    throw new FormatException($"When the encountered an error when parsing the input: {decimalReturnValues.ReturnStatus}");
                }
            }
            catch (Exception innerException)
            {
                if (innerException is FormatException)
                {
                    throw;
                }

                throw new FormatException("There was a problem processing the user input", innerException);
            }

            MetaData = decimalReturnValues.MetaData;

            if (Decimal.TryParse(decimalReturnValues.DecimalValueAsText, out Decimal result))
            {
                return result;
            }

            return null;
        }

        // Helper class, which carries the structured return values from the AI.
        private class AIDecimalParsingReturnValues
        {
            [Description("The users value after spell-checking and optional translation, when it wasn't in English.")]
            public string DecimalValueAsText { get; set; } = string.Empty;

            [Description("A brief description of what needed to be corrected or brushed up.")]
            public string MetaData { get; set; } = string.Empty;

            [Description("Either 'OK' or a brief description of what went wrong.")]
            public string ReturnStatus { get; set; } = string.Empty;
        }

        public override Task<string?> InitializeEditedValueAsync(Decimal? value, CancellationToken token) 
            => Task.FromResult<string?>(value?.ToString());
    }
}
