namespace CommunityToolkit.WinForms.ChatUI;

public class ConversationTitleChangedEventArgs(string conversationTitle) : EventArgs
{
    public string ConversationTitle { get; } = conversationTitle;
}
