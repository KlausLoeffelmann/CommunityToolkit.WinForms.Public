using CommunityToolkit.WinForms.FluentUI.Controls.TypedInputExtenders;

namespace CommunityToolkit.WinForms.FluentUI.Controls.AITypedInputExtenders;

[ToolboxBitmap(typeof(AIDateFormatterComponent), "AIFormattedDateEntry.bmp")]
public partial class AIDateFormatterComponent
    : TypedFormatterComponent<DateTime?>
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
        => (ITypedFormatter<DateTime?>)new AIDateFormatter();

    protected override object GetDefaultValue()
        => DateTime.Now.Date;

    protected override bool CanExtendProperties(object formatterComponent)
        => formatterComponent is AIDateFormatterComponent;
}