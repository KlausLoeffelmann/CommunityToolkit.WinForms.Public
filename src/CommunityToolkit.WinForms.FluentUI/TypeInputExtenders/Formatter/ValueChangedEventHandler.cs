namespace CommunityToolkit.WinForms.FluentUI.Controls.TypedInputExtenders;

/// <summary>
/// Represents the method that will handle the ValueChanged event of an object.
/// </summary>
/// <typeparam name="T">The type of the value that has changed.</typeparam>
/// <param name="sender">The source of the event.</param>
/// <param name="e">A <see cref="ValueChangedEventArgs{T}"/> that contains the event data.</param>
public delegate void ValueChangedEventHandler<T>(object? sender, ValueChangedEventArgs<T> e);

/// <summary>
/// Provides data for the ValueChanged event.
/// </summary>
/// <typeparam name="T">The type of the value that has changed.</typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="ValueChangedEventArgs{T}"/> class.
/// </remarks>
/// <param name="value">The new value.</param>
/// <param name="oldValue">The old value.</param>
/// <param name="rawInput">The raw input that caused the change.</param>
/// <param name="senderComponent">The <see cref="TypedFormatterComponent{T}"/> that raised the event.</param>
public class ValueChangedEventArgs<T>(
    T? value, 
    T? oldValue, 
    string rawInput, 
    TypedFormatterComponent<T> senderComponent) : EventArgs
{

    /// <summary>
    /// Gets the new value.
    /// </summary>
    public T? Value { get; } = value;

    /// <summary>
    /// Gets the old value.
    /// </summary>
    public T? OldValue { get; } = oldValue;

    /// <summary>
    /// Gets the raw input that caused the change.
    /// </summary>
    public string RawInput { get; } = rawInput;

    /// <summary>
    ///  Gets the <see cref="TypedFormatterComponent{T}"/> that raised the event.
    /// </summary>
    public TypedFormatterComponent<T> SenderComponent { get; } = senderComponent;
}
