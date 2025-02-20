using CommunityToolkit.WinForms.FluentUI.Controls.TypedInputExtenders;

namespace CommunityToolkit.WinForms.FluentUI.Controls.AITypedInputExtenders;

[ToolboxBitmap(typeof(AIDateFormatterComponent), "AIFormattedDecimalEntry.bmp")]
public partial class AIMeasurementFormatterComponent
    : TypedFormatterComponent<Decimal?>
{
    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
        => base.Dispose(disposing);

    public override Decimal? GetValue(Control textBox)
        => base.GetValueInternal((TextBox)textBox);

    public override void SetValue(Control textBox, Decimal? value)
        => base.SetValueInternal((TextBox)textBox, value);

    protected override ITypedFormatter<Decimal?> GetDefaultFormatterInstance()
        => (ITypedFormatter<Decimal?>)new AIMeasurementFormatter();

    protected override object GetDefaultValue()
        => DateTime.Now.Date;

    protected override bool CanExtendProperties(object formatterComponent)
        => formatterComponent is AIMeasurementFormatterComponent;
}
