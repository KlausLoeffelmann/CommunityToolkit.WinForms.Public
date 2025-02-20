namespace CommunityToolkit.DesktopGeneric.Mvvm;

public enum DialogCloseReason
{
    None,
    First,
    OK = First,
    Second,
    Cancel = Second,
    Third,
    Yes = OK,
    No = Cancel,
    Abort = First,
    Retry = Second,
    Ignore = Third,
}
