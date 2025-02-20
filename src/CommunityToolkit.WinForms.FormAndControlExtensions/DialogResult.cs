using CommunityToolkit.DesktopGeneric.Mvvm;

namespace CommunityToolkit.WinForms.Extensions;

public class ModalDialogResult<T>(T? result, DialogCloseReason dialogCloseReason) 
    : IModalDialogResult<T>
    where T : class
{
    public T? ReturnValue => result;

    DialogCloseReason IModalDialogResult<T>.DialogCloseReason => dialogCloseReason;
}
