namespace CommunityToolkit.WinForms.FluentUI.Controls.TypedInputExtenders;

[ToolboxBitmap(typeof(DateFormatterComponent), "FormattedDecimalEntry.bmp")]
public partial class DecimalFormatterComponent : TypedFormatterComponent<Decimal?>
{
    public override decimal? GetValue(Control dataEntry) 
        => base.GetValueInternal((TextBox)dataEntry);

    public override void SetValue(Control dataEntry, decimal? value) 
        => base.SetValueInternal((TextBox)dataEntry, value);

    protected override ITypedFormatter<decimal?> GetDefaultFormatterInstance() 
        => (ITypedFormatter<decimal?>)new DecimalFormatter();

    protected override bool CanExtendProperties(object formatterComponent)
        => formatterComponent is DecimalFormatterComponent;
}
