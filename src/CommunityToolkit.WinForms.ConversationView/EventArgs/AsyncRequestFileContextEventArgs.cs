namespace CommunityToolkit.WinForms.ChatUI;

/// <summary>
///  Provides data for the various events that are raised when a file needs to be extracted.
/// </summary>
public class AsyncRequestFileContextEventArgs(
    string? basePath,
    string? filename,
    string? conversationPath) : EventArgs
{
    /// <summary>
    /// Gets or sets the base path for the file extraction.
    /// </summary>
    public string? BasePath { get; } = basePath;

    /// <summary>
    /// Gets or sets the conversation path for the file extraction.
    /// </summary>
    public string? ConversationPath { get; set; } = conversationPath;

    /// <summary>
    /// Gets or sets the filename for the file extraction.
    /// </summary>
    public string? Filename { get; set; } = filename;
}
