namespace CommunityToolkit.Roslyn.Tooling;

/// <summary>
///  Represents information about a code block.
/// </summary>
public struct CodeBlockInfo
{
    /// <summary>
    ///  Gets or sets the code of the code block.
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    ///  Gets or sets the language of the code block.
    /// </summary>
    public string Language { get; set; }

    /// <summary>
    ///  Gets or sets the type of the code block.
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    ///  Gets or sets the filename associated with the code block.
    /// </summary>
    public string Filename { get; set; }

    /// <summary>
    ///  Gets or sets the description of the code block.
    /// </summary>
    public string? Description { get; set; }
}
