using CommunityToolkit.WinForms.Extensions;

namespace CommunityToolkit.WinForms.FluentUI.Controls;

public static partial class FluentSymbols
{
    /// <summary>
    /// Enum representing Segoe UI Symbol icons typically used for buttons,
    /// such as Send, Accept, Cancel, etc.
    /// </summary>
    [SourceFontName("Segoe Fluent Icons")]
    public enum CommonToolStripSymbols
    {
        /// <summary>
        /// Send
        /// Hex: E724, Decimal: 59172
        /// </summary>
        Send = 0xE724,

        /// <summary>
        /// SendFill
        /// Hex: E725, Decimal: 59173
        /// </summary>
        SendFill = 0xE725,

        /// <summary>
        /// Accept
        /// Hex: E8FB, Decimal: 59643
        /// </summary>
        Accept = 0xE8FB,

        /// <summary>
        /// Cancel
        /// Hex: E711, Decimal: 59153
        /// </summary>
        Cancel = 0xE711,

        /// <summary>
        /// AddBold
        /// Hex: F8AA, Decimal: 63658
        /// </summary>
        AddBold = 0xF8AA,

        /// <summary>
        /// New
        /// Hex: E710, Decimal: 59152
        /// </summary>
        New = AddBold,

        /// <summary>
        /// Edit
        /// Hex: E70F, Decimal: 59151
        /// </summary>
        Edit = 0xE70F,

        /// <summary>
        /// Open (OpenFile)
        /// Hex: E8E5, Decimal: 59621
        /// </summary>
        Open = OpenFile,

        /// <summary>
        /// OpenFile
        /// Hex: E8E5, Decimal: 59621
        /// </summary>
        OpenFile = 0xE8E5,

        /// <summary>
        /// OpenLocal
        /// Hex: E8DA, Decimal: 59610
        /// </summary>
        OpenLocal = 0xE8DA,

        /// <summary>
        /// Save
        /// Hex: E74E, Decimal: 59214
        /// </summary>
        Save = 0xE74E,

        /// <summary>
        /// Delete
        /// Hex: E74D, Decimal: 59213
        /// </summary>
        Delete = 0xE74D,

        /// <summary>
        /// Cut
        /// Hex: E8C6, Decimal: 59590
        /// </summary>
        Cut = 0xE8C6,

        /// <summary>
        /// Copy
        /// Hex: E8C8, Decimal: 59592
        /// </summary>
        Copy = 0xE8C8,

        /// <summary>
        /// Paste
        /// Hex: E77F, Decimal: 59263
        /// </summary>
        Paste = 0xE77F,
    }
}
