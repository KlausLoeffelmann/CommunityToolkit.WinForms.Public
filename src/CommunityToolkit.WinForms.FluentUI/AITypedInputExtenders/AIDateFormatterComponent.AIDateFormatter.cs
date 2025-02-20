using CommunityToolkit.WinForms.AI;
using CommunityToolkit.WinForms.FluentUI.Controls.TypedInputExtenders;
using System.ComponentModel;
using System.Globalization;
using System.Text.Json;

namespace CommunityToolkit.WinForms.FluentUI.Controls.AITypedInputExtenders;

public partial class AIDateFormatterComponent
{
    private static readonly DateTimeFormatInfo s_dateFormats;
    private static readonly string[] s_dateTimeFormatStrings;

    static AIDateFormatterComponent()
    {
        s_dateFormats = CultureInfo.CurrentCulture.DateTimeFormat;

        s_dateTimeFormatStrings =
        [
            s_dateFormats.ShortDatePattern,
            s_dateFormats.LongDatePattern,
            s_dateFormats.ShortDatePattern,
            s_dateFormats.LongDatePattern,
            s_dateFormats.SortableDateTimePattern,
            s_dateFormats.UniversalSortableDateTimePattern,
            s_dateFormats.RFC1123Pattern,
            s_dateFormats.ShortDatePattern + " " + s_dateFormats.ShortTimePattern
        ];
    }

    public partial class AIDateFormatter : TypedFormatter<DateTime?>
    {
        private const string OpenAiApiKeyLookupKey = "AI:OpenAi:ApiKey";
        private readonly SemanticKernelComponent _skComponent = new();

        protected const string SystemPrompt =
        """
        You are a .NET intelligent date input formatter, which task is to help find dates based on text descriptions by the user.
        You are given the current date and time.

        Examples:
            * "Tomorrow": You should return the DateTime for tomorrow.
            * "Now": You should return the current DateTime.
            * "Übermorgen": You recognize the German Language, and return the DateTime for the day after tomorrow.
            * "Kommender Montag": You recognize the German Language, and return the DateTime for the next Monday.
            * "Next Monday": You recognize the English Language, and return the DateTime for the next Monday.
            * "Boxing day": You recognize the English Language, and return the DateTime for the next Boxing, which is the 26th of December.

        Please return the corrected text as Json and take the enclosed schema into account.
        """;

        [DefaultValue(null)]
        public string? MetaData { get; set; }

        [DefaultValue(DateTimeFormats.ShortDate)]
        public DateTimeFormats DateTimeFormat { get; set; } = DateTimeFormats.ShortDate;

        public override Task<string?> ConvertToDisplayAsync(DateTime? value, CancellationToken token)
        { 
            string? returnValue = value?.ToString(GetFormatString());
            return Task.FromResult<string?>(returnValue);
        }

        public override async Task<DateTime?> ConvertToValueAsync(string? value, CancellationToken token)
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
                    "DateTimeAsText": {
                      "type": "string",
                      "description": "The user's input for a date, a time, a date-time combination or a description for a point in time."
                    },
                    "MetaData": {
                      "type": "string",
                      "description": "A brief description of what needed to do to get the required DateTime value, which can be parsed."
                    },
                    "ReturnStatus": {
                      "type": "string",
                      "description": "Either 'OK' or a brief description of what went wrong."
                    }
                  },
                  "required": ["DateTimeAsText", "MetaData", "ReturnStatus"],
                  "additionalProperties": false
                }
                """;

            string request = $"Today is {DateTime.Now}\n." +
                $"The user requested assistance for the following DateTime value or description:\n" +
                $"{value}.";

            string? jsonData = await _skComponent.RequestTextPromptResponseAsync(request, false);
            AIDateTimeParsingReturnValues? dateTimeReturnValues = null;

            if (string.IsNullOrEmpty(jsonData))
            {
                throw new InvalidOperationException("Trying to parse the text input failed for unknown reasons.");
            }

            try
            {
                dateTimeReturnValues = JsonSerializer.Deserialize<AIDateTimeParsingReturnValues>(jsonData);
                if (dateTimeReturnValues is null)
                {
                    throw new InvalidOperationException("Trying to parse the text input failed for unknown reasons.");
                }

                if (dateTimeReturnValues.ReturnStatus != "OK")
                {
                    throw new FormatException($"When the encountered an error when parsing the input: {dateTimeReturnValues.ReturnStatus}");
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

            MetaData = dateTimeReturnValues.MetaData;

            if (DateTime.TryParse(dateTimeReturnValues.DateTimeAsText, out DateTime result))
            {
                return result;
            }

            return null;
        }

        public override Task<string?> InitializeEditedValueAsync(DateTime? value, CancellationToken token) 
            => Task.FromResult<string?>(value?.ToString());

        public string GetFormatString() 
            => s_dateTimeFormatStrings[(int)DateTimeFormat];
    }
}
