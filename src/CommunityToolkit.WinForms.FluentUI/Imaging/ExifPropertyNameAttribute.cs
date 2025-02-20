namespace CommunityToolkit.WinForms.FluentUI.Imaging;

[AttributeUsage(AttributeTargets.Property)]
public class ExifPropertyNameAttribute : Attribute
{
    public ExifPropertyNameAttribute(string propertyName)
    {
        PropertyName = propertyName;
    }

    public string PropertyName { get; }
}
