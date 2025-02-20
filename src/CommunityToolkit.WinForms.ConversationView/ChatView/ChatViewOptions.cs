using CommunityToolkit.Mvvm.ComponentModel;

namespace CommunityToolkit.WinForms.ChatUI;

/// <summary>
/// Represents the options for the ChatView.
/// </summary>
/// <param name="basePath">The base path for the chat view.</param>
/// <param name="lastUsedModel">The last used model for the chat view.</param>
/// <param name="lastUsedConfigurationId">The last used configuration ID for the chat view.</param>
public partial class ChatViewOptions(string? basePath, string lastUsedModel, Guid lastUsedConfigurationId) : ObservableObject
{
    /// <summary>
    /// Gets the default model.
    /// </summary>
    public static string DefaultModel { get; } = "gpt-4o";

    /// <summary>
    /// The base path for the chat view.
    /// </summary>
    [ObservableProperty]
    private string? _basePath = basePath;

    /// <summary>
    /// The last used model for the chat view.
    /// </summary>
    [ObservableProperty]
    public string _lastUsedModel = lastUsedModel;

    /// <summary>
    /// The last used configuration ID for the chat view.
    /// </summary>
    [ObservableProperty]
    public Guid _lastUsedConfigurationId = lastUsedConfigurationId;
}
