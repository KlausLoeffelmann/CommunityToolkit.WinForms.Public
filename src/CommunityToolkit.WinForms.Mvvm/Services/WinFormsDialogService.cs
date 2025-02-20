using CommunityToolkit.DesktopGeneric.Mvvm;
using CommunityToolkit.WinForms.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace CommunityToolkit.WinForms.Mvvm;

internal partial class WinFormsDialogService(IServiceProvider serviceProvider) 
    : IMvvmDialogService
{
    private IViewLocatorService<ContainerControl> _viewLocator = default!;

    private IViewLocatorService<ContainerControl> ViewLocator
        => _viewLocator ??= serviceProvider.GetRequiredService<IViewLocatorService<ContainerControl>>();

    public async Task ShowMessageAsync(string message, string title)
    {
        var page = new TaskDialogPage()
        {
            Heading = title,
            Text = message,
            Buttons = [new TaskDialogButton("OK", true)],
        };

#pragma warning disable WFO5002 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        await TaskDialog.ShowDialogAsync(page);
#pragma warning restore WFO5002 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
    }

    public async Task<bool> ShowConfirmationAsync(string message, string title)
    {
        var page = new TaskDialogPage()
        {
            Heading = title,
            Text = message,
            Buttons = [new TaskDialogButton("OK", true)],
        };

#pragma warning disable WFO5002 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        var result = await TaskDialog.ShowDialogAsync(page);
#pragma warning restore WFO5002 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        return result == TaskDialogButton.Yes;
    }

    public async Task ShowWarningAsync(string message, string title)
    {
        var page = new TaskDialogPage()
        {
            Heading = title,
            Text = message,
            Buttons = [new TaskDialogButton("OK", true)],
            Icon = TaskDialogIcon.Warning
        };

#pragma warning disable WFO5002 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        await TaskDialog.ShowDialogAsync(page);
#pragma warning restore WFO5002 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
    }

    public async Task ShowErrorAsync(string message, string title)
    {
        var page = new TaskDialogPage()
        {
            Heading = title,
            Text = message,
            Buttons = [new TaskDialogButton("OK", true)],
            Icon = TaskDialogIcon.Error
        };

#pragma warning disable WFO5002 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        await TaskDialog.ShowDialogAsync(page);
#pragma warning restore WFO5002 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
    }

    public Task<string> RequestInputAsync(string message, string title, string defaultValue = "")
    {
        throw new NotImplementedException();
    }

    public Task<T> SelectFromAsync<T>(string message, string title, IEnumerable<T> options, T? defaultOption = default)
    {
        SelectionForm<T> selectionForm = new(message, title, options, defaultOption);

        // Show the form asynchronously
        return selectionForm.ShowDialogAsync();
    }

    public async Task<IModalDialogResult<TViewModel>> ShowDialogAsync<TViewModel, UIStack>(TViewModel viewModel)
        where TViewModel : class, INotifyPropertyChanged
        where UIStack : struct, Enum
    {
        if (ViewLocator.CreateView(viewModel) is not Form formView)
        {
            throw new InvalidOperationException("The view could not be created.");
        }
        return await formView.ShowDialogAsync<TViewModel>(viewModel);
    }
}
