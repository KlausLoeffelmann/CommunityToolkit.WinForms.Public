using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CommunityToolkit.WinForms.FluentUI.Controls.TypedInputExtenders;

/// <summary>
/// Implementation of <see cref="INotifyPropertyChanged"/> to simplify models.
/// </summary>
public abstract class TypedFormatter<T> : INotifyPropertyChanged, ITypedFormatter<T>
{
    /// <summary>
    /// event for property change notifications.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Checks if a property already matches a desired value.  Sets the property and notifies
    /// listeners only when necessary.
    /// </summary>
    /// <typeparam name="T">Type of the property.</typeparam>
    /// <param name="storage">Reference to a property with both getter and setter.</param>
    /// <param name="value">Desired value for the property.</param>
    /// <param name="propertyName">Name of the property used to notify listeners.  This value
    /// is optional and can be provided automatically when invoked from compilers that support
    /// CallerMemberName.</param>
    /// <param name="actionOnValidate">Action, which will be executes, when the validation succeeds.</param>
    /// <returns>True if the value was changed, false if the existing value matched the
    /// desired value.
    /// </returns>
    protected bool SetProperty<PropType>(
        ref PropType storage,
        PropType value,
        [CallerMemberName] string? propertyName = null,
        Func<bool>? actionOnValidate = null)
    {
        if (object.Equals(storage, value))
        {
            return false;
        }

        if (!(actionOnValidate is not null && actionOnValidate()))
        {
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Notifies listeners that a property value has changed.
    /// </summary>
    /// <param name="propertyName">Name of the property used to notify listeners.  This value
    /// is optional and can be provided automatically when invoked from compilers that support
    /// <see cref="CallerMemberNameAttribute"/>.</param>
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// Gets the format string to use when the value is null.
    /// </summary>
    protected virtual string NullFormatString => string.Empty;

    /// <summary>
    /// Converts a string representation of a value to its corresponding value of type <typeparamref name="T"/>.
    /// </summary>
    /// <param name="stringValue">The string representation of the value.</param>
    /// <returns>The converted value of type <typeparamref name="T"/>.</returns>
    public abstract Task<T?> ConvertToValueAsync(string? stringValue, CancellationToken token);
    /// <summary>
    /// Converts a value of type <typeparamref name="T"/> to its string representation.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>The string representation of the value.</returns>
    public abstract Task<string?> ConvertToDisplayAsync(T? value, CancellationToken token);
    /// <summary>
    /// Initializes the edited value of type <typeparamref name="T"/>.
    /// </summary>
    /// <param name="value">The value to initialize.</param>
    /// <returns>The initialized edited value as a string.</returns>
    public abstract Task<string?> InitializeEditedValueAsync(T? value, CancellationToken token);
}
