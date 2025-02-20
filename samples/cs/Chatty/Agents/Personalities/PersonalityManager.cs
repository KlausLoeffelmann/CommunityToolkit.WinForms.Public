using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace Chatty.ViewModels;

/// <summary>
///  Represents the view model for managing personalities.
/// </summary>
internal partial class PersonalityManager : ObservableObject
{
    private const bool MakeBackup = true;
    private const string PersonalitiesFileName = "personalities.json";

    /// <summary>
    ///  Gets or sets the list of personality items.
    /// </summary>
    [ObservableProperty()]
    public ObservableCollection<Personality> _personalities  = [];

    /// <summary>
    ///  Gets or sets the selected personality item.
    /// </summary>
    [ObservableProperty()]
    [JsonIgnore]
    public Personality? _selectedPersonality;

    /// <summary>
    ///  Writes the current instance to a JSON stream.
    /// </summary>
    /// <param name="stream">The stream to write to.</param>
    public void WriteJSon(Stream stream)
    {
        JsonWriterOptions options = new()
        {
            Indented = true,
        };

        using Utf8JsonWriter writer = new(stream, options);

        writer.WriteStartObject();
        writer.WriteStartArray(nameof(Personalities));

        foreach (Personality item in Personalities)
        {
            writer.WriteStartObject();
            item.WriteJSon(writer);
            writer.WriteEndObject();
        }

        writer.WriteEndArray();
        writer.WriteEndObject();
    }

    /// <summary>
    ///  Gets the default personality templates.
    /// </summary>
    /// <returns>A new instance of <see cref="PersonalityManager"/> with default templates.</returns>
    public static PersonalityManager GetTemplates() =>
        new()
        {
            Personalities = [.. s_personalities
                .Select(
                    (Func<KeyValuePair<string, string>, Personality>)(lookUp => new Personality
                    {
                        Name = lookUp.Key,
                        SystemPrompt = lookUp.Value,
                        FileExtractionSettings = PersonalityFileExtractionSetting.None,
                        DedicatedPersonalityFolder = string.Empty,
                        DateCreated = DateTime.Now,
                        DateLastEdited = DateTime.Now
                    }))]
        };

    /// <summary>
    ///  Creates a new instance of <see cref="PersonalityManager"/> from a JSON stream.
    /// </summary>
    /// <param name="stream">The stream to read from.</param>
    /// <returns>A new instance of <see cref="PersonalityManager"/>.</returns>
    public static PersonalityManager FromJSon(Stream stream)
    {
        PersonalityManager personality = new();

        using JsonDocument document = JsonDocument.Parse(stream);
        JsonElement root = document.RootElement;

        if (root.TryGetProperty(nameof(Personalities), out JsonElement personalitiesItemElement))
        {
            foreach (JsonElement itemElement in personalitiesItemElement.EnumerateArray())
            {
                Personality item = Personality.FromJson(itemElement);
                personality.Personalities.Add(item);
            }
        }

        return personality;
    }

    /// <summary>
    ///  Gets the personalities from the specified base path or returns the default templates if the file does not exist.
    /// </summary>
    /// <param name="basePath">The base path to look for the personalities file.</param>
    /// <returns>A new instance of <see cref="PersonalityManager"/>.</returns>
    internal static PersonalityManager GetPersonalitiesOrDefault(string basePath)
    {
        PersonalityManager personalities;

        string fileName = Path.Combine(basePath, PersonalitiesFileName);
        if (File.Exists(fileName))
        {
            using FileStream readerStream = File.OpenRead(fileName);
            personalities = PersonalityManager.FromJSon(readerStream);

            return personalities;
        }

        personalities = PersonalityManager.GetTemplates();
        personalities.SavePersonalities(basePath);

        return personalities;
    }

    internal void SavePersonalities(string basePath)
    {
        string fileName = Path.Combine(basePath, PersonalitiesFileName);

        if (MakeBackup)
        {
            string backupFileName = Path.Combine(basePath, $"{PersonalitiesFileName}.bak");
            File.Copy(fileName, backupFileName, true);
        }

        using FileStream writerStream = File.Create(fileName);
        WriteJSon(writerStream);
    }

    private static readonly Dictionary<string, string> s_personalities = new()
        {
            {
                "Default",
                "You are a friendly, versatile Assistant, trying to address all requests to the best of your abilities, "
              + "and you are engaged, even if folks just want to chat. But you politely decline requests "
              + "that are inappropriate or impolite."
            },
            {
                "Funny/Ironic",
                "You are a witty and ironic Assistant, always ready with a playful quip or punchline. Provide helpful answers, "
              + "but pepper them with dry humor or lighthearted irony. Keep responses fun, yet respectful."
            },
            {
                "Shakespearean",
                "You are a Shakespearean bard. Speak in the style of Elizabethan English, employing flowery prose and "
              + "theatrical flourishes when you respond, yet strive to remain clear in your meaning."
            },
            {
                "Sarcastic/Grumpy",
                "You are sarcastic and even funny-grumpy. You answer questions directly, but with a hint of annoyance or a sarcastic quip. "
              + "Keep the humor gentle—don’t cross the line into being offensive, but definitely be sassy!"
            },
            {
                "Translate to Klingon",
                "You are a Klingon translator. Try to provide a valid translation into Klingon, "
              + "and add comments on to best pronounce it or that the entered phrased had to be paraphrased."
              + "Please return the actual translated phrase in bold and italic, and additional explanations in a standard font."
            }
        };
}
