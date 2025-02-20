using Chatty.Properties;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.WinForms.AI;
using CommunityToolkit.WinForms.Controls.Tooling.IO;

using System.Text.Json;

namespace Chatty.ViewModels;

/// <summary>
///  Represents a view model for a personality item.
/// </summary>
internal partial class Personality : ObservableObject
{
    private static string? s_codeBlockAddendum;

    public Personality() { }

    public Personality(Personality personality)
    {
        Id = personality.Id;
        Name = personality.Name;
        SystemPrompt = personality.SystemPrompt;
        DateCreated = personality.DateCreated;
        DateLastEdited = DateTime.Now;
        FileExtractionSettings = personality.FileExtractionSettings;
    }

    /// <summary>
    /// Gets or sets the unique identifier for the personality item.
    /// </summary>
    [ObservableProperty]
    private Guid _id = Guid.NewGuid();

    /// <summary>
    /// Gets or sets the name of the personality item.
    /// </summary>
    [ObservableProperty]
    private string _name = string.Empty;

    /// <summary>
    /// Gets or sets the system prompt associated with the personality item.
    /// </summary>
    [ObservableProperty]
    private string _systemPrompt = string.Empty;

    /// <summary>
    /// Gets or sets the date and time when the personality item was created.
    /// </summary>
    [ObservableProperty]
    private DateTime _dateCreated = DateTime.Now;

    /// <summary>
    /// Gets or sets the date and time when the personality item was last edited.
    /// </summary>
    [ObservableProperty]
    private DateTime _dateLastEdited = DateTime.Now;

    [ObservableProperty]
    private PersonalityFileExtractionSetting _fileExtractionSettings = PersonalityFileExtractionSetting.None;

    [ObservableProperty]
    private string _dedicatedPersonalityFolder = string.Empty;

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString() => $"{Name}";

    /// <summary>
    /// Creates a new instance of <see cref="Personality"/> from a JSON element.
    /// </summary>
    /// <param name="jsonElement">The JSON element to parse.</param>
    /// <returns>A new instance of <see cref="Personality"/>.</returns>
    public static Personality FromJson(JsonElement jsonElement)
    {
        Personality personalityVm = new()
        {
            Id = jsonElement.GetProperty(nameof(Id)).GetGuid(),
            Name = jsonElement.GetProperty(nameof(Name)).GetString() ?? string.Empty,
            SystemPrompt = jsonElement.GetProperty(nameof(SystemPrompt)).GetString() ?? string.Empty,
            DateCreated = jsonElement.GetProperty(nameof(DateCreated)).GetDateTime(),
            DateLastEdited = jsonElement.GetProperty(nameof(DateLastEdited)).GetDateTime()
        };

        if (jsonElement.TryGetProperty(nameof(FileExtractionSettings), out JsonElement fileExtractionSetting))
        {
            personalityVm.FileExtractionSettings = (PersonalityFileExtractionSetting) fileExtractionSetting.GetInt32();
        }

        if (jsonElement.TryGetProperty(nameof(DedicatedPersonalityFolder), out JsonElement dedicatedPersonalityFolder))
        {
            string personalityFolder = dedicatedPersonalityFolder.GetString() ?? string.Empty;

            if (!string.IsNullOrEmpty(personalityFolder) && personalityFolder.Contains('%'))
            {
                personalityFolder = FilenameDisambiguator.ExpandPath(personalityFolder);
                personalityVm.DedicatedPersonalityFolder = personalityFolder;
            }
            else
            {
                personalityVm.DedicatedPersonalityFolder = personalityFolder;
            }
        }

        return personalityVm;
    }

    /// <summary>
    /// Writes the current instance to a JSON writer.
    /// </summary>
    /// <param name="writer">The JSON writer to write to.</param>
    public void WriteJSon(Utf8JsonWriter writer)
    {
        string dedicatedPersonalityFolder = DedicatedPersonalityFolder;

        try
        {
            if (!string.IsNullOrEmpty(dedicatedPersonalityFolder))
            {
                // Let's try to shrink the path to make it universal roamable.
                dedicatedPersonalityFolder = FilenameDisambiguator.ShrinkPath(dedicatedPersonalityFolder);
            }

        }
        catch (Exception)
        {
        }

        writer.WriteString(nameof(Id), Id);
        writer.WriteString(nameof(Name), Name);
        writer.WriteString(nameof(SystemPrompt), SystemPrompt);
        writer.WriteNumber(nameof(FileExtractionSettings), (int) FileExtractionSettings);
        writer.WriteString(nameof(DedicatedPersonalityFolder), dedicatedPersonalityFolder);
        writer.WriteString(nameof(DateCreated), DateCreated);
        writer.WriteString(nameof(DateLastEdited), DateLastEdited);
    }

    public string GetDeveloperPrompt()
        => FileExtractionSettings.HasFlag(PersonalityFileExtractionSetting.ExtractAutomatically)
        ? $"{SystemPrompt}{CodeBlockAddendum}"
        : SystemPrompt;

    private static readonly string CodeBlockAddendum = s_codeBlockAddendum ??=
        Resources.CodeBlockAddendum
            .Replace("[0]", SemanticKernelComponent.CodeBlockTypeMetaTag)
            .Replace("[1]", SemanticKernelComponent.CodeBlockFilenameMetaTag)
            .Replace("[2]", SemanticKernelComponent.CodeBlockDescriptionMetaTag);
}
