using CommunityToolkit.WinForms.AI;
using CommunityToolkit.WinForms.AI.SemanticKernel;

namespace CommunityToolkit.WinForms.FluentUI.Controls;

public partial class AutoCompleteEditor : RichTextBox, IUsesSemanticKernelComponent
{
    private SemanticKernelComponent _semanticKernel = new();

    private void SetupSemanticKernel()
    {
        IUsesSemanticKernelComponent.ProvidePropertyProcessingDelegates(
            this,
            () => _semanticKernel);
    }

    Func<SemanticKernelComponent>? IUsesSemanticKernelComponent.SemanticKernelGetter { get; set; }
}
