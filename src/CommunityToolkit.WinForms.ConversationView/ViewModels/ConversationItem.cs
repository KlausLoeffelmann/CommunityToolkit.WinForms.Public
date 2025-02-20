using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.WinForms.ChatUI.Extension;
using System.Text.Json;

namespace CommunityToolkit.WinForms.ChatUI;

public partial class ConversationItem : ObservableObject
{
    [ObservableProperty]
    private string? _markdownContent;

    [ObservableProperty]
    private string? _htmlContent;

    [ObservableProperty]
    private bool _isResponse;

    [ObservableProperty]
    private string? _backColor;

    [ObservableProperty]
    private string? _foreColor;

    [ObservableProperty]
    private DateTimeOffset _dateCreated;

    [ObservableProperty]
    private TimeSpan _firstResponseDuration;

    [ObservableProperty]
    private TimeSpan _completeProcessDuration;


    public override string? ToString() 
        => MarkdownContent ?? HtmlContent ?? base.ToString();

    public void WriteJSon(Utf8JsonWriter writer)
    {
        writer.WriteString(nameof(MarkdownContent), MarkdownContent);
        writer.WriteBoolean(nameof(IsResponse), IsResponse);
        writer.WriteString(nameof(BackColor), BackColor);
        writer.WriteString(nameof(ForeColor), ForeColor);
        writer.WriteString(nameof(DateCreated), DateCreated);
        writer.WriteString(nameof(FirstResponseDuration), FirstResponseDuration.ToString());
        writer.WriteString(nameof(CompleteProcessDuration), CompleteProcessDuration.ToString());
    }

    public static ConversationItem FromJsonElement(JsonElement jsonElement)
    {
        var conversationItemViewModel = new ConversationItem
        {
            MarkdownContent = jsonElement.GetPropertyOrDefault(nameof(MarkdownContent), string.Empty),
            IsResponse = jsonElement.GetPropertyOrDefault(nameof(IsResponse), false),
            BackColor = jsonElement.GetPropertyOrDefault(nameof(BackColor), string.Empty),
            ForeColor = jsonElement.GetPropertyOrDefault(nameof(ForeColor), string.Empty),
            DateCreated = jsonElement.GetPropertyOrDefault(nameof(DateCreated), DateTime.Now),
            FirstResponseDuration = jsonElement.GetPropertyOrDefault(nameof(FirstResponseDuration), TimeSpan.MinValue),
            CompleteProcessDuration = jsonElement.GetPropertyOrDefault(nameof(CompleteProcessDuration), TimeSpan.MinValue)
        };

        return conversationItemViewModel;
    }
}
