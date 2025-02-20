using System.ComponentModel;

namespace CommunityToolkit.WinForms.FluentUI.Controls.AITypedInputExtenders;

public partial class AIDateFormatterComponent
{

    public partial class AIDateFormatter
    {
        // Helper class, which carries the structured return values from the AI.
        private class AIDateTimeParsingReturnValues
        {
            [Description("The users value after spell-checking and optional translation, when it wasn't in English.")]
            public string DateTimeAsText { get; set; } = string.Empty;

            [Description("A brief description of what needed to be corrected or brushed up.")]
            public string MetaData { get; set; } = string.Empty;

            [Description("Either 'OK' or a brief description of what went wrong.")]
            public string ReturnStatus { get; set; } = string.Empty;
        }
    }
}
