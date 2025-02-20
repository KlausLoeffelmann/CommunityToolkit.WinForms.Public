using System.ComponentModel;
using System.Globalization;

namespace CommunityToolkit.WinForms.FluentUI.Controls.TypedInputExtenders;

public class TypedFormatterTypeConverter : TypeConverter
{
    private const string IDataEntryFormatterOfName = "ITypedFormatter`1";
    private const string FormattingPropertiesName = "(FormattingProperties)";

    public override bool GetPropertiesSupported(ITypeDescriptorContext? context) => true;

    public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType) 
        => destinationType == typeof(string)
            ? FormattingPropertiesName
            : base.ConvertTo(context, culture, value, destinationType);

    public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext? context, object? value, Attribute[]? attributes) 
        => value?.GetType().GetInterface(IDataEntryFormatterOfName) != null
            ? TypeDescriptor.GetProperties(value, null)
            : new PropertyDescriptorCollection([]);
}
