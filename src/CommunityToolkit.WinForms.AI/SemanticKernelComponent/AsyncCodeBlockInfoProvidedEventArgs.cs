using CommunityToolkit.Roslyn.Tooling;

namespace CommunityToolkit.WinForms.AI;

/// <summary>
///  Provides data for the AsyncListingFileProvided event.
/// </summary>
public class AsyncCodeBlockInfoProvidedEventArgs(CodeBlockInfo codeBlock)
    : EventArgs
{
    /// <summary>
    ///  Gets the listing file associated with the event.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when the listing file is null.</exception>
    public CodeBlockInfo CodeBlock { get; } = codeBlock;

    /// <summary>
    ///  Gets or sets a value indicating whether the 
    ///  event has been handled.
    /// </summary>
    public bool Handled { get; set; }
}
