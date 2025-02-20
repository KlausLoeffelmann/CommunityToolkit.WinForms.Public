using System.ComponentModel;

namespace CommunityToolkit.DesktopGeneric.Mvvm;

public interface IModalDialogResult<TViewModel>
    where TViewModel : class
{
    TViewModel? ReturnValue { get; }

    DialogCloseReason DialogCloseReason { get; }
}
