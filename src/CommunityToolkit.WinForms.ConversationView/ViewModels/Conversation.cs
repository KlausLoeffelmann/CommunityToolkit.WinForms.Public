using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.WinForms.ChatUI.Extension;
using Markdig;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace CommunityToolkit.WinForms.ChatUI;

public partial class Conversation()
    : ObservableObject
{
    [ObservableProperty]
    private Guid _id;

    [ObservableProperty]
    private string? _headline;

    [ObservableProperty]
    private string _title = string.Empty;

    partial void OnTitleChanging(string value)
    {
        Debug.Print($"Conversation.OnTitleChanging value={value}");
    }

    [ObservableProperty]
    private string _summary = string.Empty;

    [ObservableProperty]
    private string _keywords = string.Empty;

    [ObservableProperty]
    private int _tokenCount;

    [ObservableProperty]
    private string _filename = string.Empty;

    [ObservableProperty]
    private DateTimeOffset _dateCreated = DateTimeOffset.Now;

    [ObservableProperty]
    private DateTimeOffset _dateLastEdited = DateTimeOffset.Now;

    [ObservableProperty]
    private string _backColor = string.Empty;

    [ObservableProperty]
    private string _foreColor = string.Empty;

    [ObservableProperty]
    private string? _responseInProgress;

    [ObservableProperty]
    private string? _currentListingInfo;

    [ObservableProperty]
    private string? _responseInProgressBackColor;

    [ObservableProperty]
    private string _model="- undefined -";

    [ObservableProperty]
    private Guid _idPersonality;

    [ObservableProperty]
    private ObservableCollection<ConversationItem> _conversationItems = [];

    [ObservableProperty]
    private TimeSpan _lastKickOffTime;

    [ObservableProperty]
    private TimeSpan _firstResponseDuration;

    [ObservableProperty]
    private TimeSpan _completeProcessDuration;

    [ObservableProperty]
    private bool _viewUpdatesSuspended = false;

    public void WriteJSon(Stream stream)
    {
        ArgumentNullException.ThrowIfNull(stream, nameof(stream));

        JsonWriterOptions options = new()
        {
            Indented = true,
        };

        // Let's use System.Text.Json to serialize the object:
        using Utf8JsonWriter writer = new(stream, options);

        writer.WriteStartObject();
        writer.WriteString(nameof(Id), Id);
        writer.WriteString(nameof(Title), Title);
        writer.WriteString(nameof(Filename), Filename);
        writer.WriteString(nameof(DateCreated), DateCreated);
        writer.WriteString(nameof(DateLastEdited), DateLastEdited);
        writer.WriteString(nameof(Summary), Summary);
        writer.WriteString(nameof(Keywords), Keywords);
        writer.WriteNumber(nameof(TokenCount), TokenCount);
        writer.WriteString(nameof(Model), Model);
        writer.WriteString(nameof(IdPersonality), IdPersonality);

        writer.WriteStartArray(nameof(ConversationItems));

        foreach (ConversationItem item in ConversationItems)
        {
            writer.WriteStartObject();
            item.WriteJSon(writer);
            writer.WriteEndObject();
        }

        writer.WriteEndArray();
        writer.WriteEndObject();
    }

    /// <summary>
    ///  Loads conversation items from a JSON string.
    /// </summary>
    /// <param name="json">The JSON string representing the conversation items.</param>
    public static Conversation FromJson(string json)
    {
        try
        {
            using MemoryStream stream = new(Encoding.UTF8.GetBytes(json));
            Conversation conversation = Conversation.FromJson(stream);
            ProcessMarkdownToHTML(conversation);

            return conversation;
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Processes markdown content into HTML, handling nested code blocks using a counter.
    /// Assumes that code blocks always start with a line like "```something" and end
    /// with a line that is exactly "```".
    /// </summary>
    /// <param name="conversation">The conversation containing markdown items.</param>
    private static void ProcessMarkdownToHTML(Conversation conversation)
    {
        foreach (ConversationItem item in conversation.ConversationItems)
        {
            int index = 0;

            StringBuilder htmlContent = new();
            StringBuilder listingContent = new();
            int listingCounter = 0;

            while (true)
            {
                ReadOnlySpan<char> paragraph = GetNextParagraph(item.MarkdownContent.AsSpan(), ref index);

                if (paragraph.Length == 0)
                {
                    break;
                }

                string currentParagraph = paragraph.ToString();
                string trimmed = currentParagraph.Trim();

                // Check for an opening fence with a language specifier.
                if (trimmed.StartsWith("```") && trimmed.Length > 3)
                {
                    if (listingCounter == 0)
                    {
                        // For the outermost listing, output a header with the listing type.
                        string listingType = trimmed[3..].Trim();
                        htmlContent.Append($"<listing>{listingType}</listing>\n");
                    }

                    listingContent.Append(currentParagraph);
                    listingCounter++;

                    continue;
                }
                else if (trimmed == "```" && listingCounter > 0)
                {
                    // Found a closing fence.
                    listingContent.Append(currentParagraph);
                    listingCounter--;

                    if (listingCounter == 0)
                    {
                        // When the outermost listing is closed, process the accumulated content.
                        htmlContent.Append(Markdown.ToHtml(listingContent.ToString()));
                        listingContent.Clear();
                    }

                    continue;
                }
                else
                {
                    // If we're inside a listing, accumulate content; otherwise, process normally.
                    if (listingCounter > 0)
                    {
                        listingContent.Append(currentParagraph);
                    }
                    else
                    {
                        htmlContent.Append(Markdown.ToHtml(currentParagraph));
                    }
                }
            }

            item.HtmlContent = htmlContent.ToString();
        }
    }

    /// <summary>
    /// Returns the next "paragraph" (line) from the given text starting at <paramref name="offset"/>.
    /// Handles different newline conventions: LF, CR, and CRLF.
    /// Advances <paramref name="offset"/> to the start of the following line.
    /// </summary>
    /// <param name="text">The text to read from.</param>
    /// <param name="offset">
    /// The starting index in <paramref name="text"/>. On return, it points to the beginning of the next line.
    /// </param>
    /// <returns>
    /// A <see cref="ReadOnlySpan{Char}"/> containing the next paragraph, or an empty span if the offset is at the end.
    /// </returns>
    private static ReadOnlySpan<char> GetNextParagraph(ReadOnlySpan<char> text, ref int offset)
    {
        if (offset >= text.Length)
        {
            return [];
        }

        int start = offset;

        while (offset < text.Length)
        {
            char c = text[offset];

            if (c is '\n' or '\r')
            {
                // Handle CRLF: if current char is CR and next char is LF.
                if (c == '\r' && offset + 1 < text.Length 
                    && text[offset + 1] == '\n')
                {
                    offset += 2;
                }
                else
                {
                    offset++;
                }

                ReadOnlySpan<char> paragraph = text[start..offset];
                return paragraph;
            }

            offset++;
        }

        // No newline found; return the remaining text.
        return text[start..];
    }

    public static Conversation FromJson(Stream stream)
    {
        ArgumentNullException.ThrowIfNull(stream, nameof(stream));

        using JsonDocument document = JsonDocument.Parse(stream);
        JsonElement root = document.RootElement;

        Conversation conversation = Conversation.GetHeaderFromRoot(root);

        if (!root.TryGetProperty(nameof(ConversationItems), out JsonElement conversationItemsElement))
        {
            return conversation;
        }

        foreach (JsonElement itemElement in conversationItemsElement.EnumerateArray())
        {
            ConversationItem item = ConversationItem.FromJsonElement(itemElement);
            conversation.ConversationItems.Add(item);
        }

        return conversation;
    }

    public static Conversation? GetHeaderFromFile(string fileName)
    {
        try
        {
            using Stream stream = File.OpenRead(fileName);
            Conversation item = GetHeaderFromStream(stream);

            // We fix this, if this info isn't there (version change.)
            // Should it get serialized, this will be then fixed.
            if (item.Id == Guid.Empty)
            {
                item.Id = Guid.NewGuid();
            }

            if (string.IsNullOrEmpty(item.Filename))
            {
                item.Filename = fileName;
            }

            return item;
        }
        catch (Exception)
        {
            return null;
        }
    }

    partial void OnResponseInProgressChanging(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            Debug.Print($"Response in progress changed: {value}");
        }
    }

    public static Conversation GetHeaderFromStream(Stream stream)
    {
        using JsonDocument document = JsonDocument.Parse(stream);
        JsonElement root = document.RootElement;

        Conversation conversation = GetHeaderFromRoot(root);

        return conversation;
    }

    private static Conversation GetHeaderFromRoot(JsonElement root)
    {
        Conversation conversation = new();

        conversation.Title = root.GetPropertyOrDefault(nameof(Title), conversation.Title);
        conversation.Id = root.GetPropertyOrDefault(nameof(Id), conversation.Id);
        conversation.Filename = root.GetPropertyOrDefault(nameof(Filename), conversation.Filename);
        conversation.DateCreated = root.GetPropertyOrDefault(nameof(DateCreated), conversation.DateCreated);
        conversation.DateLastEdited = root.GetPropertyOrDefault(nameof(DateLastEdited), conversation.DateLastEdited);
        conversation.Summary = root.GetPropertyOrDefault(nameof(Summary), conversation.Summary);
        conversation.Keywords = root.GetPropertyOrDefault(nameof(Keywords), conversation.Keywords);
        conversation.TokenCount = root.GetPropertyOrDefault(nameof(TokenCount), conversation.TokenCount);
        conversation.Model = root.GetPropertyOrDefault(nameof(Model), conversation.Model);
        conversation.IdPersonality = root.GetPropertyOrDefault(nameof(IdPersonality), conversation.IdPersonality);

        return conversation;
    }

    /// <summary>
    ///  Gets the default title for a conversation. IMPORTANT: $0200 is a zero-width space, 
    ///  which is our marker for a new conversation and that the LLM has yet to come up with a new name.
    /// </summary>
    /// <returns></returns>
    public static string GetDefaultTitle() => $"\u200B{DateTime.Now:MMM ddd dd, HH:mm}";

    internal void SuspendUpdates()
    {
        if (ViewUpdatesSuspended)
        {
            throw new InvalidOperationException("Updates are already suspended.");
        }

        ViewUpdatesSuspended = true;
    }

    internal void ResumeUpdates()
    {
        if (!ViewUpdatesSuspended)
        {
            throw new InvalidOperationException("Updates are not suspended.");
        }

        ViewUpdatesSuspended = false;
    }
}
