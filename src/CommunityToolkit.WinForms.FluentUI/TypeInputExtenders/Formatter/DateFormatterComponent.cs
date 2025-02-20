namespace CommunityToolkit.WinForms.FluentUI.Controls.TypedInputExtenders;

[ToolboxBitmap(typeof(DateFormatterComponent), "FormattedDateEntry.bmp")]
public partial class DateFormatterComponent : TypedFormatterComponent<DateTime?>
{
    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) 
        => base.Dispose(disposing);

    public override DateTime? GetValue(Control textBox) 
        => base.GetValueInternal((TextBox)textBox);

    public override void SetValue(Control textBox, DateTime? value) 
        => base.SetValueInternal((TextBox)textBox, value);

    protected override ITypedFormatter<DateTime?> GetDefaultFormatterInstance() 
        => (ITypedFormatter<DateTime?>)new DateFormatter();

    protected override bool CanExtendProperties(object formatterComponent) 
        => formatterComponent is DateFormatterComponent;
}
