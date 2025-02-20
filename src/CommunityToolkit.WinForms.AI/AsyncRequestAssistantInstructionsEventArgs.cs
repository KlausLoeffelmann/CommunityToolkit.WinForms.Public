using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace CommunityToolkit.WinForms.AI;

public class AsyncRequestExecutionSettingsEventArgs(OpenAIPromptExecutionSettings executionSettings) : EventArgs
{
    public OpenAIPromptExecutionSettings ExecutionSettings { get; set; } = executionSettings;
}
