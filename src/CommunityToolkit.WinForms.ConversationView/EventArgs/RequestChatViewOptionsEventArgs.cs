namespace CommunityToolkit.WinForms.ChatUI;

/// <summary>
/// Provides data for the RequestChatViewOptions event.
/// </summary>
public class RequestChatViewOptionsEventArgs : EventArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RequestChatViewOptionsEventArgs"/> class.
    /// </summary>
    /// <param name="basePath">The base path for the chat view.</param>
    /// <param name="lastUsedModel">The last used model for the chat view.</param>
    /// <param name="lastUsedConfigurationId">The last used configuration ID for the chat view.</param>
    public RequestChatViewOptionsEventArgs(string? basePath, string lastUsedModel, Guid lastUsedConfigurationId)
    {
        BasePath = basePath;
        LastUsedModel = lastUsedModel;
        LastUsedConfigurationId = lastUsedConfigurationId;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RequestChatViewOptionsEventArgs"/> class.
    /// </summary>
    /// <param name="options">The chat view options.</param>
    public RequestChatViewOptionsEventArgs(ChatViewOptions options)
    {
        BasePath = options.BasePath;
        LastUsedModel = options.LastUsedModel;
        LastUsedConfigurationId = options.LastUsedConfigurationId;
    }

    /// <summary>
    /// Gets the base path for the chat view.
    /// </summary>
    public string? BasePath { get; set; }

    /// <summary>
    /// Gets the last used model for the chat view.
    /// </summary>
    public string LastUsedModel { get; set; }

    /// <summary>
    /// Gets the last used configuration ID for the chat view.
    /// </summary>
    public Guid LastUsedConfigurationId { get; set; }
}
