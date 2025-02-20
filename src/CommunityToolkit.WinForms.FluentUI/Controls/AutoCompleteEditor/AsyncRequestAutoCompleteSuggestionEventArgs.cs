using System;

namespace CommunityToolkit.WinForms.FluentUI.Controls;

public class AsyncRequestAutoCompleteSuggestionEventArgs : EventArgs
{
    public string CurrentParagraph { get; }
    public string OldParagraph { get; }
    public bool IsCursorAtEnd { get; }
    public int CursorLocation { get; }
    public string SuggestionText { get; set; }

    public AsyncRequestAutoCompleteSuggestionEventArgs(string currentParagraph, string oldParagraph, bool isCursorAtEnd, int cursorLocation, string suggestionText)
    {
        CurrentParagraph = currentParagraph;
        OldParagraph = oldParagraph;
        IsCursorAtEnd = isCursorAtEnd;
        CursorLocation = cursorLocation;
        SuggestionText = suggestionText;
    }
}
