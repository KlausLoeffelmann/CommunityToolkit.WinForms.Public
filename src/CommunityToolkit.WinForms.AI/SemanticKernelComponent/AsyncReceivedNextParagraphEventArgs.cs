namespace CommunityToolkit.WinForms.AI;

/// <summary>
/// Provides data for the event that is triggered when the next paragraph is received asynchronously.
/// </summary>
/// <param name="paragraph">The content of the received paragraph.</param>
/// <param name="textPosition">The position of the text in the document.</param>
/// <param name="isLastParagraph">Indicates whether this is the last paragraph.</param>
public class AsyncReceivedNextParagraphEventArgs(string paragraph, int textPosition, bool isLastParagraph) : EventArgs
{
    /// <summary>
    /// Gets the content of the received paragraph.
    /// </summary>
    public string Paragraph { get; } = paragraph;

    /// <summary>
    /// Gets the position of the text in the document.
    /// </summary>
    public int TextPosition { get; } = textPosition;

    /// <summary>
    /// Gets a value indicating whether this is the last paragraph.
    /// </summary>
    public bool IsLastParagraph { get; } = isLastParagraph;
}
