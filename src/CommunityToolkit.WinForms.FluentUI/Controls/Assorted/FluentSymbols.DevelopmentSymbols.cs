using CommunityToolkit.WinForms.Extensions;

namespace CommunityToolkit.WinForms.FluentUI.Controls;

public static partial class FluentSymbols
{
    /// <summary>
    /// Enum representing Segoe UI Symbol icons filtered for a Development theme,
    /// such as those for code, components (classes), files, and tools.
    /// </summary>
    [SourceFontName("Segoe Fluent Icons")]
    public enum DevelopmentSymbols
    {
        /// <summary>
        /// Code – can represent a code block or method.
        /// Hex: E943, Decimal: 59715
        /// </summary>
        Code = 0xE943,

        /// <summary>
        /// Component – may be used to represent a class or component.
        /// Hex: E950, Decimal: 59728
        /// </summary>
        Component = 0xE950,

        /// <summary>
        /// DeveloperTools – symbolizing development tools.
        /// Hex: EC7A, Decimal: 60538
        /// </summary>
        DeveloperTools = 0xEC7A,

        /// <summary>
        /// Project – for a project or solution.
        /// Hex: EBC6, Decimal: 60358
        /// </summary>
        Project = 0xEBC6,

        /// <summary>
        /// FileExplorer – representing file navigation or a source folder.
        /// Hex: E8E5, Decimal: 59621
        /// </summary>
        FileExplorer = 0xE8E5,

        /// <summary>
        /// Document – can be used for source files or properties.
        /// Hex: E8A5, Decimal: 59557
        /// </summary>
        Document = 0xE8A5,

        /// <summary>
        /// IBeam – representing a text editor or code view.
        /// Hex: E933, Decimal: 59499
        /// </summary>
        IBeam = 0xE933,

        /// <summary>
        /// TextEdit – another symbol for editing text.
        /// Hex: EF60, Decimal: 61280
        /// </summary>
        TextEdit = 0xEF60,

        /// <summary>
        /// CommandPrompt – representing a terminal or command-line interface.
        /// Hex: E756, Decimal: 59222
        /// </summary>
        CommandPrompt = 0xE756,
    }
}
