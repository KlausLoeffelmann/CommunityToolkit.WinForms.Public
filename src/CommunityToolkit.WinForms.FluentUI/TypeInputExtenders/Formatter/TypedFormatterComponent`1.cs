using CommunityToolkit.WinForms.FluentUI.Controls;
using System.ComponentModel;

namespace CommunityToolkit.WinForms.FluentUI.Controls.TypedInputExtenders;

/// <summary>
/// Provides a base class for components that extend <see cref="TextBox"/> controls with formatting capabilities
/// and value conversion for data entry purposes.
/// </summary>
/// <typeparam name="T">The type of the value being formatted and converted.</typeparam>
[ToolboxBitmap(typeof(DateFormatterComponent), "CustomControl.bmp")]
[ProvideProperty("FormatterSettings", typeof(TextBox))]
[ProvideProperty("Value", typeof(TextBox))]
public abstract partial class TypedFormatterComponent<T> :
    BindableComponent, IExtenderProvider, ITypedFormatterComponent
{
    /// <summary>
    /// Occurs when InitializeComponent has been done with setting up this component.
    /// </summary>
    public event EventHandler? NotifyEndInit;

    /// <summary>
    /// Occurs when a property value changes.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Occurs when the value associated with a <see cref="TextBox"/> control changes.
    /// </summary>
    public event ValueChangedEventHandler<T>? ValueChanged;

    public event EventHandler<ValueConvertEventArgs>? ValueConverting;
    public event EventHandler<ValueConvertEventArgs>? ValueConverted;

    private readonly Dictionary<Control, ITypedFormatter<T>> _propertyStorage = [];
    private readonly Dictionary<Control, T?> _valueStorage = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="TypedFormatterComponent{T}"/> class.
    /// </summary>
    public TypedFormatterComponent() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="TypedFormatterComponent{T}"/> class with the specified container.
    /// </summary>
    /// <param name="container">The container to add the component to.</param>
    public TypedFormatterComponent(IContainer container)
        => container.Add(this);

    bool IExtenderProvider.CanExtend(object extendee)
    {
        // Check if the extendee is a TextBox and if it is a child of a DataEntryPanel
        if (extendee is TextBox textBox
            && GetAncestorOf<TypedInputExtenderPanel>(textBox) is TypedInputExtenderPanel panel)
        {
            ITypedFormatterComponent? formatterComponent = panel.GetFormatterComponent(textBox);
            bool canExtend = formatterComponent is not null && CanExtendProperties(formatterComponent);
            if (canExtend)
            {
                // If the component can extend the TextBox, let's see if we already have the default 
                // instance of the formatter component's properties. If not, we'll get and store it:
                if (GetFormatterSettings(textBox) is null)
                {
                    SetFormatterSettings(textBox, GetDefaultFormatterInstance());
                }
            }

            return canExtend;
        }

        return false;
    }

    // Retrieves the closest ancestor of a specified type for a given control.
    private static TControl? GetAncestorOf<TControl>(Control? control) where TControl : Control
        => control is null
            ? null
            : control is TControl ancestor
                ? ancestor
                : GetAncestorOf<TControl>(control.Parent);

    /// <summary>
    /// Determines whether the properties of a formatter component can be extended.
    /// </summary>
    /// <param name="formatterComponent">The formatter component to check.</param>
    /// <returns><see langword="true"/> if the properties can be extended; otherwise, <see langword="false"/>.</returns>
    protected abstract bool CanExtendProperties(object formatterComponent);

    /// <summary>
    /// Gets the internal value associated with the specified <see cref="TextBox"/>.
    /// </summary>
    /// <param name="textBox">The <see cref="TextBox"/> to retrieve the value for.</param>
    /// <returns>The value associated with the specified <see cref="TextBox"/>, or <see langword="null"/> if not set.</returns>
    protected T? GetValueInternal(TextBox textBox)
        => _valueStorage.TryGetValue(textBox, out T? value)
            ? value
            : default;

    /// <summary>
    /// Sets the internal value associated with the specified <see cref="TextBox"/>.
    /// </summary>
    /// <param name="textBox">The <see cref="TextBox"/> to set the value for.</param>
    /// <param name="value">The value to associate with the <see cref="TextBox"/>.</param>
    protected void SetValueInternal(TextBox textBox, T? value)
    {
        if (!_valueStorage.TryAdd(textBox, value))
        {
            T? oldValue = _valueStorage[textBox];
            if (!object.Equals(oldValue, value))
            {
                _valueStorage[textBox] = value;

                OnValueChanged(
                    sender: textBox,
                    e: new ValueChangedEventArgs<T>(
                        value: oldValue,
                        oldValue: value,
                        rawInput: textBox.Text,
                        senderComponent: this));
            }
        }
    }

    /// <summary>
    /// Raises the <see cref="ValueChanged"/> event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A <see cref="ValueChangedEventArgs{T}"/> that contains the event data.</param>
    protected virtual void OnValueChanged(object sender, ValueChangedEventArgs<T> e)
        => ValueChanged?.Invoke(sender, e);

    /// <summary>
    /// Gets the formatting properties associated with the specified <see cref="Control"/>.
    /// </summary>
    /// <param name="textBox">The control to retrieve the formatting properties for.</param>
    /// <returns>
    /// The <see cref="ITypedFormatter{T}"/> associated with the control, or <see langword="null"/> if not set.
    /// </returns>
    [Category("Data Entry Extension")]
    [DisplayName("-> FormatterSettings")]
    [RefreshProperties(RefreshProperties.All)]
    public ITypedFormatter<T>? GetFormatterSettings(Control textBox)
        => _propertyStorage.TryGetValue(textBox, out ITypedFormatter<T>? value)
            ? value
            : null;

    /// <summary>
    /// Sets the formatting properties associated with the specified <see cref="Control"/>.
    /// </summary>
    /// <param name="textBox">The control to set the formatting properties for.</param>
    /// <param name="value">The <see cref="ITypedFormatter{T}"/> to associate with the control.</param>
    public void SetFormatterSettings(Control textBox, ITypedFormatter<T> value)
        => _propertyStorage.TryAdd(textBox, value);

    /// <summary>
    /// Gets the value associated with the specified <see cref="Control"/>.
    /// </summary>
    /// <param name="textBox">The control to retrieve the value for.</param>
    /// <returns>The value associated with the control, or <see langword="null"/> if not set.</returns>
    [Category("Data Entry Extension")]
    [DisplayName("-> Value")]
    [Bindable(true)]
    abstract public T? GetValue(Control textBox);

    /// <summary>
    /// Sets the value associated with the specified <see cref="Control"/>.
    /// </summary>
    /// <param name="textBox">The control to set the value for.</param>
    /// <param name="value">The value to associate with the control.</param>
    abstract public void SetValue(Control textBox, T? value);

    /// <inheritdoc/>
    object? ITypedFormatterComponent.GetValue(TextBox textBox)
        => GetValue(textBox);

    /// <inheritdoc/>
    void ITypedFormatterComponent.SetValue(TextBox textBox, object? value)
        => SetValue(textBox, (T?)value);

    /// <summary>
    /// Attempts to convert a string to a value and assign it to the specified <see cref="TextBox"/>.
    /// </summary>
    /// <param name="textBox">The <see cref="TextBox"/> to set the value for.</param>
    /// <param name="stringValue">The string to convert to a value.</param>
    /// <returns>
    /// <see langword="true"/> if the conversion succeeded and the value was assigned; otherwise, <see langword="false"/>.
    /// </returns>
    public async Task<bool> TryConvertToValueAsync(TextBox textBox, string? stringValue, CancellationToken token)
    {
        T? valueTemp;
        ValueConvertEventArgs valueConvertEventArgs = new(textBox, token);

        try
        {

            OnValueConverting(valueConvertEventArgs);
            ITypedFormatter<T>? temp = GetFormatterSettings(textBox);

            valueTemp = temp is null
                ? default
                : await temp.ConvertToValueAsync(stringValue, token);
        }
        catch (OperationCanceledException)
        {
            // For Debugging purposes.
            throw;
        }
        catch (Exception)
        {
            return false;
        }
        finally
        {
            OnValueConverted(valueConvertEventArgs);
        }

        SetValue(textBox, valueTemp);

        return true;
    }

    protected virtual void OnValueConverting(ValueConvertEventArgs eArgs)
    {
        ValueConverting?.Invoke(this, eArgs);

        if (eArgs.TextBox.ReadOnly)
        {
            eArgs.PreventChangesWhileBusy = false;
        }

        if (eArgs.PreventChangesWhileBusy)
        {
            eArgs.TextBox.ReadOnly = true;
        }

        if (eArgs.IndicateBusy && eArgs.TextBox.Parent is ScrollableControl parent)
        {
            // We are putting a SpinnerControl at the end of the TextBox to indicate that the conversion is in progress.
            parent.SuspendLayout();
            eArgs.Spinner = new SpinnerControl();
            parent.Controls.Add(eArgs.Spinner);
            eArgs.Spinner.Top = eArgs.TextBox.Top + (eArgs.TextBox.Height - eArgs.Spinner.Height) / 2;
            eArgs.Spinner.Left = eArgs.TextBox.Right - eArgs.Spinner.Width;
            eArgs.Spinner.BringToFront();
            eArgs.SpinnerTask = eArgs.Spinner.SpinAsync(eArgs.CancellationTokenSource.Token);
            parent.ResumeLayout();
        }
    }

    protected virtual async void OnValueConverted(ValueConvertEventArgs eArgs)
    {
        if (eArgs.PreventChangesWhileBusy)
        {
            eArgs.TextBox.ReadOnly = false;
        }

        if (eArgs.IndicateBusy)
        {
            eArgs.CancellationTokenSource!.Cancel();

            try
            {
                await eArgs.SpinnerTask!;
            }
            catch (OperationCanceledException)
            {
            }

            eArgs.TextBox.Parent?.Controls.Remove(eArgs.Spinner);
            eArgs.Spinner!.Dispose();
        }

        ValueConverted?.Invoke(this, eArgs);
    }

    /// <summary>
    /// Converts the value associated with the specified <see cref="TextBox"/> to a displayable string.
    /// </summary>
    /// <param name="textBox">The <see cref="TextBox"/> to retrieve the value for.</param>
    /// <returns>A string representation of the value, or <see langword="null"/> if the conversion fails.</returns>
    public Task<string?> ConvertToDisplayAsync(TextBox textBox, CancellationToken token)
    {
        ITypedFormatter<T>? formatterSettings = GetFormatterSettings(textBox);

        return formatterSettings is null
            ? Task.FromResult<string?>(null)
            : formatterSettings.ConvertToDisplayAsync(GetValue(textBox), token);
    }

    /// <summary>
    /// Initializes the value for editing in the specified <see cref="TextBox"/>.
    /// </summary>
    /// <param name="textBox">The <see cref="TextBox"/> to initialize the value for.</param>
    /// <returns>
    /// A string representation of the initial value, or <see langword="null"/> if the initialization fails.
    /// </returns>
    public Task<string?> InitializeEditedValueAsync(TextBox textBox, CancellationToken token)
    {
        ITypedFormatter<T>? formatterSettings = GetFormatterSettings(textBox);

        return formatterSettings is null
            ? Task.FromResult<string?>(null)
            : formatterSettings.InitializeEditedValueAsync(GetValue(textBox), token);
    }

    /// <inheritdoc/>
    object? ITypedFormatterComponent.GetDefaultValue()
        => GetDefaultValue();

    /// <summary>
    /// Gets the default formatter instance for the component.
    /// </summary>
    /// <returns>An instance of <see cref="ITypedFormatter{T}"/>.</returns>
    abstract protected ITypedFormatter<T> GetDefaultFormatterInstance();

    /// <summary>
    /// Gets the default value for the component.
    /// </summary>
    /// <returns>The default value for the component.</returns>
    protected virtual object? GetDefaultValue()
        => default(T);

    /// <inheritdoc/>
    void ISupportInitialize.BeginInit()
    {
    }

    /// <inheritdoc/>
    void ISupportInitialize.EndInit()
    {
        NotifyEndInit?.Invoke(this, EventArgs.Empty);
    }

    public async Task<object?> TryGetValueAsync(string text, CancellationToken token)
    {
        ITypedFormatter<T> formatter = GetDefaultFormatterInstance();
        object? value = await formatter.ConvertToValueAsync(text, token);
        return value;
    }
}
