namespace CommunityToolkit.WinForms.FluentUI.Controls;

public class AsyncSendCommandEventArgs(
    AutoCompleteEditorCommand editorCommand,
    string? commandText = null,
    string? rtfCommandText = null) : EventArgs
{
    public AutoCompleteEditorCommand EditorCommand { get; } = editorCommand;
    public string? CommandText { get; set; } = commandText;
    public string? RTFCommandText { get; set; } = rtfCommandText;
}
