namespace CommunityToolkit.WinForms.FluentUI.Controls.TypedInputExtenders;

public partial class TypedInputExtenderPanel
{
    private class TypedInputExtenderProperties(
        ITypedFormatterComponent? formatterComponent, 
        Color? focusColor, 
        Color? errorColor)
    {
        internal Color? FocusColor { get; set; } = focusColor;
        internal FocusSelectionBehavior FocusSelectionBehavior { get; set; } 
            = FocusSelectionBehavior.SelectAll;

        internal Color? ErrorColor { get; set; } = errorColor;
        internal string? ErrorText { get; set; } = string.Empty;
        internal ITypedFormatterComponent? FormatterComponent { get; set; } 
            = formatterComponent;

        internal bool HasFocus { get; set; }
        internal string? EditedValue { get; set; }
        internal bool HasError { get; set; }
        internal Color OriginalBackColor { get; set; }
        internal bool ChangingValueInternally { get; set; }
        internal object? ValueInternal { get; set; }
        internal bool CommitOnFocusedRead { get; set; }
        internal string? DebugName { get; set; }
        internal CancellationTokenSource? CancellationTokenSource { get; set; }
    }
}
