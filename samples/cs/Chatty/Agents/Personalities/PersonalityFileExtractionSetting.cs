namespace Chatty.ViewModels;

[Flags]
internal enum PersonalityFileExtractionSetting
{
    /// <summary>No extraction.</summary>
    None = 0,

    /// <summary>Don't extract any files (default).</summary>
    DoNotExtract = 1,

    /// <summary>Extract code blocks automatically as Markdown.</summary>
    ExtractAutomatically = 2,

    /// <summary>Save extracted files to the conversation folder.</summary>
    SaveToConversationFolder = 4,

    /// <summary>Save extracted files to a dedicated Personality folder.</summary>
    SaveToDedicatedPersonalityFolder = 8,

    /// <summary>Store extracted files in subfolders by conversation title.</summary>
    StoreInSubfoldersByTitle = 16
}
