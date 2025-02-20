using System.ComponentModel;

namespace CommunityToolkit.DesktopGeneric.Mvvm;

/// <summary>
///  Represents a service for displaying user interface dialogs and messages.
/// </summary>
public interface IMvvmDialogService
{
    /// <summary>
    ///  Display a simple message to the user.
    /// </summary>
    /// <param name="message">The message to display.</param>
    /// <param name="title">The title of the message dialog.</param>
    Task ShowMessageAsync(string message, string title);

    /// <summary>
    ///  Ask the user a yes/no question.
    /// </summary>
    /// <param name="message">The question to ask.</param>
    /// <param name="title">The title of the confirmation dialog.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the user's response.</returns>
    Task<bool> ShowConfirmationAsync(string message, string title);

    /// <summary>
    ///  Display a warning message to the user.
    /// </summary>
    /// <param name="message">The warning message to display.</param>
    /// <param name="title">The title of the warning dialog.</param>
    Task ShowWarningAsync(string message, string title);

    /// <summary>
    ///  Display an error message to the user.
    /// </summary>
    /// <param name="message">The error message to display.</param>
    /// <param name="title">The title of the error dialog.</param>
    Task ShowErrorAsync(string message, string title);

    /// <summary>
    ///  Request simple text input from the user.
    /// </summary>
    /// <param name="message">The message to display in the input dialog.</param>
    /// <param name="title">The title of the input dialog.</param>
    /// <param name="defaultValue">The default value to display in the input field.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the user's input.</returns>
    Task<string> RequestInputAsync(string message, string title, string defaultValue = "");

    /// <summary>
    ///  Show a dialog to select from a list of options.
    /// </summary>
    /// <param name="message">The message to display in the selection dialog.</param>
    /// <param name="title">The title of the selection dialog.</param>
    /// <param name="options">The list of options to select from.</param>
    /// <param name="defaultOption">The default option to select.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the selected option.</returns>
    Task<T> SelectFromAsync<T>(string message, string title, IEnumerable<T> options, T? defaultOption = default);

    /// <summary>
    ///  Display a custom dialog, allowing for more complex interactions and inputs.
    /// </summary>
    /// <typeparam name="TViewModel">The type of the view model.</typeparam>
    /// <param name="viewModel">The view model for the custom dialog.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the dialog result.</returns>
    public Task<IModalDialogResult<TViewModel>> ShowDialogAsync<TViewModel, UIStack>(TViewModel viewModel)
        where TViewModel : class, INotifyPropertyChanged
        where UIStack : struct, Enum;
}
