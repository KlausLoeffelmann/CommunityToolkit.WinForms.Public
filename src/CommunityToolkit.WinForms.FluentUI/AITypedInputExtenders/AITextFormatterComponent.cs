using CommunityToolkit.WinForms.FluentUI.Controls.TypedInputExtenders;

namespace CommunityToolkit.WinForms.FluentUI.Controls.AITypedInputExtenders;

[ToolboxBitmap(typeof(AITextFormatterComponent), "AIFormattedTextEntry.bmp")]
public partial class AITextFormatterComponent
    : TypedFormatterComponent<string?>
{
    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
        => base.Dispose(disposing);

    public override string? GetValue(Control textBox)
        => base.GetValueInternal((TextBox)textBox);

    public override void SetValue(Control textBox, string? value)
        => base.SetValueInternal((TextBox)textBox, value);

    protected override ITypedFormatter<string?> GetDefaultFormatterInstance()
        => (ITypedFormatter<string?>)new AITextFormatter();

    protected override object GetDefaultValue()
        => string.Empty;

    protected override bool CanExtendProperties(object formatterComponent)
        => formatterComponent is AITextFormatterComponent;
}

