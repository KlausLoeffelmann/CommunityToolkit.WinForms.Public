using CommunityToolkit.WinForms.AI;
using CommunityToolkit.WinForms.FluentUI.Controls.TypedInputExtenders;
using System.ComponentModel;
using System.Text.Json;

namespace CommunityToolkit.WinForms.FluentUI.Controls.AITypedInputExtenders;

public partial class AITextFormatterComponent
{
    public class AITextFormatter : TypedFormatter<string?>
    {
        private const string OpenAiApiKeyLookupKey = "AI:OpenAi:ApiKey";
        private readonly SemanticKernelComponent _skComponent = new();

        protected const string SystemPrompt =
        """
        You are an .NET intelligent text input formatter, which task is to spell-check and clean up text entries.

        Examples:
        * Input was: "Remind me to buy dog food.": You return the string as is, since it doesn't have any typos.
        * Input was: "Remind me to bought dog food.": You recognize the wrong verb tense, and correct it so it becomes: "Remind me to buy dog food."
        * Input was: "Rimind me too bye doc foot.": You recognize, there are a lot of typos - try the best to correct it: "Remind me to buy dog food."
        * Input was: "Erinnere mich daran, Hundefutter zu kaufen.": You recognize the German Language, and translate it to English.

        Please return the corrected text as Json and take the enclosed schema into account.
        """;

        [DefaultValue(null)]
        public string? MetaData { get; set; }

        // Done on Got-Focus. We take the typed value, convert it to a string, and show it in the TextBox.
        public override Task<string?> ConvertToDisplayAsync(string? value, CancellationToken token)
            => Task.FromResult<string?>(value);

        // Done on Lost Focus/Validate. We take the user input (the string) and try to convert it into the target type.
        public override async Task<string?> ConvertToValueAsync(string? value, CancellationToken token)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
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
                    "CorrectedValue": {
                      "type": "string",
                      "description": "The user's value after spell-checking and optional translation, when it wasn't in English."
                    },
                    "MetaData": {
                      "type": "string",
                      "description": "A brief description of what needed to be corrected or brushed up."
                    },
                    "ReturnStatus": {
                      "type": "string",
                      "description": "Either 'OK' or a brief description of what went wrong."
                    }
                  },
                  "required": ["CorrectedValue", "MetaData", "ReturnStatus"],
                  "additionalProperties": false
                }
                """;

            string? jsonData = await _skComponent.RequestTextPromptResponseAsync(value, false);
            AITextParsingReturnValues? translationReturnValues = null;

            if (string.IsNullOrEmpty(jsonData))
            {
                throw new InvalidOperationException("Trying to parse the text input failed for unknown reasons.");
            }

            try
            {
                translationReturnValues = JsonSerializer.Deserialize<AITextParsingReturnValues>(jsonData);
                if (translationReturnValues is null)
                {
                    throw new InvalidOperationException("Trying to parse the text input failed for unknown reasons.");
                }

                if (translationReturnValues.ReturnStatus != "OK")
                {
                    throw new FormatException($"When the encountered an error when parsing the input: {translationReturnValues.ReturnStatus}");
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

            MetaData = translationReturnValues.MetaData;
            return translationReturnValues.CorrectedValue;
        }

        // Helper class, which carries the structured return values from the AI.
        private class AITextParsingReturnValues
        {
            [Description("The users value after spell-checking and optional translation, when it wasn't in English.")]
            public string CorrectedValue { get; set; } = string.Empty;

            [Description("A brief description of what needed to be corrected or brushed up.")]
            public string MetaData { get; set; } = string.Empty;

            [Description("Either 'OK' or a brief description of what went wrong.")]
            public string ReturnStatus { get; set; } = string.Empty;
        }

        // This is the method which produces the initial value for the TextBox.
        public override Task<string?> InitializeEditedValueAsync(string? value, CancellationToken token)
            => Task.FromResult<string?>(value);
    }
}
