using System.ComponentModel;

namespace CommunityToolkit.DesktopGeneric.Mvvm;

public interface IViewModelFactoryService
{
    TViewModel CreateViewModel<TViewModel>() 
        where TViewModel : class, INotifyPropertyChanged;
}
