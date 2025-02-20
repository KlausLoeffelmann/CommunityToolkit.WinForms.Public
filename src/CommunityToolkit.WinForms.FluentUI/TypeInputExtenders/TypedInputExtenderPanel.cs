using System.ComponentModel;
using System.Diagnostics;

namespace CommunityToolkit.WinForms.FluentUI.Controls.TypedInputExtenders;

[ProvideProperty("FocusColor", typeof(TextBox))]
[ProvideProperty("FocusSelectionBehavior", typeof(TextBox))]
[ProvideProperty("FormatterComponent", typeof(TextBox))]
[ProvideProperty("ErrorColor", typeof(TextBox))]
[ProvideProperty("ErrorText", typeof(TextBox))]
[ToolboxBitmap(typeof(TypedInputExtenderPanel), "TypedInputExtender.bmp")]
public partial class TypedInputExtenderPanel : Panel, IExtenderProvider
{
    private readonly Dictionary<TextBox, TypedInputExtenderProperties> _propertyStorage = [];
    private readonly ToolTip _toolTip = new();

    bool IExtenderProvider.CanExtend(object extendee)
    {
        // We only want to extend TextBoxes:
        return extendee is TextBox textBox
            && IsThisAncestorOf(textBox);

        bool IsThisAncestorOf(Control control)
            => control.Parent == this
                || (control.Parent is not null && IsThisAncestorOf(control.Parent));
    }

    // This is the method the DataEntryFormatterComponent will call to determine if
    // it can extend the TextBox.
    internal bool CanDataEntryComponentExtend(TextBox textBox)
        => _propertyStorage.ContainsKey(textBox);

    [Category("Data Entry Extension")]
    [DisplayName("FormatterComponent")]
    [ParenthesizePropertyName(true)]
    [RefreshProperties(RefreshProperties.All)]
    public ITypedFormatterComponent? GetFormatterComponent(TextBox textBox)
        => EnsureProperties(textBox).FormatterComponent;

    private TypedInputExtenderProperties EnsureProperties(TextBox textBox)
    {
        if (!_propertyStorage.TryGetValue(textBox, out TypedInputExtenderProperties? value))
        {
            value = new TypedInputExtenderProperties(null, DefaultFocusColor, DefaultErrorColor);
            _propertyStorage.Add(textBox, value);
            WireTextbox(textBox);
        }

        return value;
    }

    public void SetFormatterComponent(TextBox textBox, ITypedFormatterComponent? formatterComponent)
    {
        TypedInputExtenderProperties properties = null!;

        if (formatterComponent is null)
        {
            UnwireTextBox(textBox);
            _propertyStorage.Remove(textBox);
        }
        else
        {
            properties = EnsureProperties(textBox);
            properties.FormatterComponent = formatterComponent;

            formatterComponent.NotifyEndInit += FormatterComponent_NotifyEndInit;
        }

        async void FormatterComponent_NotifyEndInit(object? sender, EventArgs e)
        {
            properties.DebugName = textBox.Name;
            await SetObjectValueAsync(textBox, properties, formatterComponent.GetValue(textBox));
            await UpdateDisplayAsync(properties, textBox);
            formatterComponent.NotifyEndInit -= FormatterComponent_NotifyEndInit;
        }
    }

    private async Task<object?> GetObjectValueAsync(TextBox textBox, TypedInputExtenderProperties properties)
    {
        if (properties.HasFocus && properties.CommitOnFocusedRead)
        {
            properties.EditedValue = textBox.Text;
            await TryCommitInputAsync(properties, textBox);
        }

        return properties.ValueInternal;
    }

    private static async Task SetObjectValueAsync(TextBox textBox, TypedInputExtenderProperties properties, object? value)
    {
        if (object.Equals(value, properties.ValueInternal))
        {
            return;
        }

        properties.ValueInternal = value;

        if (!properties.ChangingValueInternally && properties.FormatterComponent is not null)
        {
            properties.FormatterComponent.SetValue(textBox, properties.ValueInternal);

            properties.EditedValue = await properties.FormatterComponent.InitializeEditedValueAsync(
                textBox,
                properties.CancellationTokenSource?.Token ?? CancellationToken.None);

            await UpdateDisplayAsync(
                properties, 
                textBox);
        }
    }

    [Category("Data Entry Extension")]
    [DefaultValue(null)]
    public Color? DefaultFocusColor { get; set; }

    [Category("Data Entry Extension")]
    [DefaultValue(null)]
    public Color? DefaultErrorColor { get; set; }

    [Category("Data Entry Extension")]
    [DisplayName("-> FocusColor")]
    [Bindable(true)]
    public Color? GetFocusColor(TextBox textBox)
        => EnsureProperties(textBox).FocusColor;

    public void SetFocusColor(TextBox textBox, Color? value)
        => EnsureProperties(textBox).FocusColor = value;

    [Category("Data Entry Extension")]
    [DisplayName("-> ErrorColor")]
    [Bindable(true)]
    public Color? GetErrorColor(TextBox textBox)
        => EnsureProperties(textBox).ErrorColor;

    public void SetErrorColor(TextBox textBox, Color? value)
        => EnsureProperties(textBox).ErrorColor = value;

    [Category("Data Entry Extension")]
    [DisplayName("-> ErrorText")]
    [Bindable(true)]
    public string? GetErrorText(TextBox textBox)
        => EnsureProperties(textBox).ErrorText;

    public void SetErrorText(TextBox textBox, string? value)
        => EnsureProperties(textBox).ErrorText = value;

    private void WireTextbox(TextBox textBox)
    {
        textBox.GotFocus += TextBox_GotFocus;
        textBox.LostFocus += TextBox_LostFocus;
        textBox.Validating += TextBox_Validating;
    }

    private void UnwireTextBox(TextBox textBox)
    {
        textBox.GotFocus -= TextBox_GotFocus;
        textBox.LostFocus -= TextBox_LostFocus;
        textBox.Validating -= TextBox_Validating;
    }

    private void TextBox_GotFocus(object? sender, EventArgs e)
    {
        TextBox textBox = (TextBox)sender!;
        TypedInputExtenderProperties properties = _propertyStorage[textBox];

        if (properties.CancellationTokenSource is CancellationTokenSource tokenSource)
        {
            Debug.Print($"Cancelling previous token: {textBox.Name}");
            tokenSource.Cancel();
        }

        properties.CancellationTokenSource = new CancellationTokenSource();
        properties.HasFocus = true;
        textBox.Text = properties.EditedValue;

        HandleFocusHighlight(textBox, properties, !properties.HasError);

        switch (properties.FocusSelectionBehavior)
        {
            case FocusSelectionBehavior.SelectAll:
                textBox.SelectAll();
                break;
            case FocusSelectionBehavior.PlaceCaretAtEnd:
                textBox.SelectionStart = textBox.Text!.Length;
                textBox.SelectionLength = 0;
                break;
            default:
                textBox.SelectionStart = 0;
                textBox.SelectionLength = 0;
                break;
        }
    }

    private static void HandleFocusHighlight(TextBox textBox, TypedInputExtenderProperties properties, bool savePreviousColorState)
    {
        if (savePreviousColorState)
        {
            properties.OriginalBackColor = textBox.BackColor;
        }

        if (properties.FocusColor.HasValue)
        {
            textBox.BackColor = properties.HasError
                ? (properties.ErrorColor ?? Color.OrangeRed)
                : properties.FocusColor.Value;
        }
        else
        {
            textBox.BackColor = properties.HasError
                ? (properties.ErrorColor ?? Color.OrangeRed)
                : textBox.BackColor;
        }
    }

    private void TextBox_LostFocus(object? sender, EventArgs e)
    {
        TextBox textBox = (TextBox)sender!;
        TypedInputExtenderProperties properties = _propertyStorage[textBox];

        textBox.BackColor = properties.OriginalBackColor;
    }

    private async void TextBox_Validating(object? sender, CancelEventArgs e)
    {
        TextBox textBox = (TextBox)sender!;
        TypedInputExtenderProperties properties = _propertyStorage[textBox];

        properties.EditedValue = textBox.Text;

        if (properties.FormatterComponent is ITypedFormatterComponent dataEntryFormatter)
        {
            try
            {
                if (await TryCommitInputAsync(properties, textBox))
                {
                    try
                    {
                        var token = properties.CancellationTokenSource?.Token ?? CancellationToken.None;
                        var convertedValue = await dataEntryFormatter.ConvertToDisplayAsync(
                            textBox,
                            token);

                        if (!token.IsCancellationRequested)
                        {
                            textBox.Text = convertedValue;
                        }
                    }
                    finally
                    {
                    }

                    if (properties.HasError)
                    {
                        properties.HasError = false;
                    }
                }

                else
                {
                    properties.HasError = true;
                    _toolTip.Show(properties.ErrorText, textBox);
                }
            }
            catch (OperationCanceledException)
            {
                Debug.Print($"TryCommitInputAsync cancelled: {textBox.Name}");
            }
            finally
            {
                properties.HasFocus = false;

                HandleFocusHighlight(
                    textBox: textBox,
                    properties: properties,
                    savePreviousColorState: properties.HasFocus);
            }
        }
    }

    private static async Task<bool> TryCommitInputAsync(TypedInputExtenderProperties properties, TextBox textBox)
    {
        if (properties.FormatterComponent is not ITypedFormatterComponent dataEntryFormatter)
        {
            return false;
        }

        if (await dataEntryFormatter.TryConvertToValueAsync(
            textBox: textBox,
            stringValue: properties.EditedValue,
            token: properties.CancellationTokenSource?.Token ?? CancellationToken.None))
        {
            try
            {
                properties.ChangingValueInternally = true;
                await SetObjectValueAsync(textBox, properties, dataEntryFormatter.GetValue(textBox));
            }
            finally
            {
                properties.ChangingValueInternally = false;
            }

            return true;
        }

        return false;
    }

    private async static Task UpdateDisplayAsync(TypedInputExtenderProperties properties, TextBox textBox)
    {
        if (properties.HasFocus)
        {
            textBox.Text = properties.EditedValue;
        }
        else
        {
            var token = properties.CancellationTokenSource?.Token ?? CancellationToken.None;

            string? textValue = await properties.FormatterComponent!.ConvertToDisplayAsync(
                textBox: textBox,
                token: token);

            if (!token.IsCancellationRequested)
            {
                textBox.Text = textValue;
            }
        }
    }
}
