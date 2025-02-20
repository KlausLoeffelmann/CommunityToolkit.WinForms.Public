namespace Chatty.ViewModels;

/// <summary>
/// ViewModel for application options.
/// </summary>
internal class OptionsViewModel
{
    /// <summary>
    /// Gets or sets a value indicating whether to archive chats.
    /// </summary>
    public bool ArchiveChats { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to automatically copy the last answer to the clipboard.
    /// </summary>
    public bool AutoClipboardLastAnswer { get; set; }

    /// <summary>
    /// Gets or sets the base path for application data.
    /// </summary>
    public string BasePath { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Chatty";

    public string LastUsedModel { get; set; } = "gpt-4o";

    public Guid LastUsedIdPersonality { get; set; }
}
