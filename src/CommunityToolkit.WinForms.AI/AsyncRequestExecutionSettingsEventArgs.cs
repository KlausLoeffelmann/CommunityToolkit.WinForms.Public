namespace CommunityToolkit.WinForms.AI;

public class AsyncRequestAssistantInstructionsEventArgs(string? assistanceInstructions) : EventArgs
{
    public string? AssistantInstructions { get; set; } = assistanceInstructions;
}
