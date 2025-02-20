using System.ComponentModel;
using System.Windows.Input;

namespace CommunityToolkit.WinForms.Extensions.FormAndControlExtensions;

/// <summary>
///  Represents a command that can be used in WinForms applications.
/// </summary>
/// <remarks>
///  <para>
///   This class implements the <see cref="ICommand"/> and <see cref="INotifyPropertyChanged"/> interfaces.
///   It provides a way to bind actions and conditions to UI elements in a WinForms application.
///  </para>
///  <para>
///   The command can be executed if the <see cref="CanExecuteFunc"/> returns true or if it is null.
///   The <see cref="CommandAction"/> is invoked when the command is executed.
///  </para>
///  <para>
///   <b>Note:</b> This class has been refactored to make it easier to implement commands by overriding some new methods.
///   Currently, it may seem a bit redundant, but we will split this class later into two which build on each other.
///   For now, to test what works best, we leave it like that.
///  </para>
///  <para>
///   <b>Note:</b> The extension method <see cref="BindableComponentExtensions.BindCommand"/> in 
///   <see cref="CommunityToolkit.WinForms.Extensions.FormAndControlExtensions.BindableComponentExtensions"/> works best 
///   to setup a real binding, where you also can control the <see cref="ToolStripMenuItem.Checked"/> property
///   of the <see cref="ToolStripMenuItem"/> with and also easily provide an image for the
///   <see cref="ToolStripMenuItem.Image"/> property via the <c>FluentSymbols</c> class.
///  </para>
/// </remarks>
public class WinFormsCommand : ICommand, INotifyPropertyChanged
{
    private bool _checked;

    /// <summary>
    ///  Initializes a new instance of the <see cref="WinFormsCommand"/> class.
    /// </summary>
    /// <param name="commandAction">The action to be executed by the command.</param>
    /// <param name="canExecuteFunc">The function that determines whether the command can execute.</param>
    /// <param name="imageProviderFunc">The function that provides the image associated with the command.</param>
    public WinFormsCommand(
        Action<object?>? commandAction,
        Func<object?, bool>? canExecuteFunc = null,
        Func<Image?>? imageProviderFunc = null)
    {
        CommandAction = commandAction ?? Command;
        CanExecuteFunc = canExecuteFunc ?? CanExecute;
        ImageProviderFunc = imageProviderFunc ?? GetImage;
    }

    /// <summary>
    ///  The default command action.
    /// </summary>
    /// <param name="parameter">The parameter passed to the command.</param>
    protected virtual void Command(object? parameter) { }

    /// <summary>
    ///  The default function to determine if the command can execute.
    /// </summary>
    /// <param name="parameter">The parameter passed to the command.</param>
    /// <returns>True if the command can execute; otherwise, false.</returns>
    protected virtual bool CanExecute(object? parameter) => true;

    /// <summary>
    ///  The default function to get the image associated with the command.
    /// </summary>
    /// <returns>The image associated with the command.</returns>
    protected virtual Image? GetImage() => null;

    /// <summary>
    ///  Occurs when changes occur that affect whether or not the command should execute.
    /// </summary>
    public event EventHandler? CanExecuteChanged;

    /// <summary>
    ///  Occurs when a property value changes.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    ///  Gets the action to be executed by the command.
    /// </summary>
    private Action<object?>? CommandAction { get; }

    /// <summary>
    /// Gets the function that determines whether the command can execute.
    /// </summary>
    private Func<object?, bool>? CanExecuteFunc { get; }

    /// <summary>
    ///  Gets the function that provides the image associated with the command.
    /// </summary>
    private Func<Image?>? ImageProviderFunc { get; }

    /// <summary>
    ///  Notifies that the ability of the command to execute has changed.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This method raises the <see cref="CanExecuteChanged"/> event.
    ///  </para>
    /// </remarks>
    public void NotifyCanExecuteChanged()
        => OnCanExecuteChanged();

    /// <summary>
    ///  Gets or sets a value indicating whether the command is checked.
    /// </summary>
    public bool Checked
    {
        get => _checked;
        set
        {
            if (_checked != value)
            {
                _checked = value;
                OnPropertyChanged(nameof(Checked));
            }
        }
    }

    /// <summary>
    /// Gets the image associated with the command.
    /// </summary>
    public Image? Image
        => ImageProviderFunc?.Invoke();

    bool ICommand.CanExecute(object? parameter)
        => OnCanExecute(parameter);

    void ICommand.Execute(object? parameter)
        => OnExecute(parameter);

    /// <summary>
    ///  Determines whether the command can execute in its current state.
    /// </summary>
    /// <param name="parameter">
    ///  Data used by the command. If the command does not require data to be passed,
    ///  this object can be set to null.
    /// </param>
    /// <returns>true if this command can be executed; otherwise, false.</returns>
    protected virtual bool OnCanExecute(object? parameter)
        => CanExecuteFunc?.Invoke(parameter) ?? true;

    /// <summary>
    ///  Executes the command.
    /// </summary>
    /// <param name="parameter">
    ///  Data used by the command. If the command does not require data
    ///  to be passed, this object can be set to null.
    /// </param>
    protected virtual void OnExecute(object? parameter)
        => CommandAction?.Invoke(parameter);

    /// <summary>
    ///  Raises the <see cref="CanExecuteChanged"/> event.
    /// </summary>
    protected virtual void OnCanExecuteChanged()
        => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

    /// <summary>
    ///  Raises the <see cref="PropertyChanged"/> event.
    /// </summary>
    /// <param name="propertyName">The name of the property that changed.</param>
    protected virtual void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
