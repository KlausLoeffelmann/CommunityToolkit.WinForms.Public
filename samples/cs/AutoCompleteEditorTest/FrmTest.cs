using CommunityToolkit.WinForms.FluentUI.Controls;

namespace AutoCompleteEditorTest;

public partial class FrmTest : Form
{
    public FrmTest()
    {
        InitializeComponent();
    }

    private async Task AutoCompleteEditor_AsyncRequestAutoCompleteSuggestion(
        object sender, 
        AsyncRequestAutoCompleteSuggestionEventArgs e)
    {
        await _debugConsole.WriteLineAsync(
            $"RequestAutoComplete:\n" +
            $"       {nameof(e.IsCursorAtEnd)}:{e.IsCursorAtEnd}\n" +
            $"      {nameof(e.CursorLocation)}:{e.CursorLocation}\n" +
            $"    {nameof(e.CurrentParagraph)}:{e.CurrentParagraph}\n\n");

        e.SuggestionText = "SuggestionText";
    }

    private async Task AutoCompleteEditor_AsyncSendCommand
        (object sender, 
        AsyncSendCommandEventArgs e)
    {
        await _debugConsole.WriteLineAsync(
            $"AsyncSendCommand: {e.CommandText}");
    }
}
