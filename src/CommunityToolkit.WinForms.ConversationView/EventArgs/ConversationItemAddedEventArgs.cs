namespace CommunityToolkit.WinForms.ChatUI;

public class ConversationItemAddedEventArgs(ConversationItem conversationItem) : EventArgs
{
    public ConversationItem ConversationItem { get; } = conversationItem;
}
