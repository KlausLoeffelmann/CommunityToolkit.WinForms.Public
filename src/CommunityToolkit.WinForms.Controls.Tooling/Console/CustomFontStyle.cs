namespace CommunityToolkit.WinForms.Controls.Tooling.Console;

[Flags]
public enum CustomFontStyle
{
    /// <summary>
    /// Represents normal font style.
    /// </summary>
    Normal = 0,

    /// <summary>
    /// Represents bold font style.
    /// </summary>
    Bold = 1,

    /// <summary>
    /// Represents italic font style.
    /// </summary>
    Italic = 2,

    /// <summary>
    /// Represents underline font style.
    /// </summary>
    Underline = 4,

    /// <summary>
    /// Represents strikethrough font style.
    /// </summary>
    StrikeThrough = 8
}
