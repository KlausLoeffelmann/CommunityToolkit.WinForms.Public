using CommunityToolkit.WinForms.AI;

using System.Diagnostics;

namespace CommunityToolkit.WinForms.ChatUI;

public partial class ChatView : UserControl
{
    private readonly Lock _conversationLock = new();

    private async Task SKCommunicator_ReceivedNextParagraph(
        object? sender, AsyncReceivedNextParagraphEventArgs e)
    {
        lock (_conversationLock)
        {
            _conversationProcessor ??= new(
                    conversation: ConversationView.Conversation,
                    _options.BasePath
                        ?? throw new InvalidOperationException("BasePath is not set."));
        }

        await _conversationProcessor.HandleNewParagraphAsync(
            paragraph: e.Paragraph,
            textPosition: e.TextPosition,
            isLastParagraph: e.IsLastParagraph);

        Debug.Print(e.Paragraph);
    }
}
