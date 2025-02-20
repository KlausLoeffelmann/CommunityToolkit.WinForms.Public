namespace CommunityToolkit.WinForms.Extensions;

[AttributeUsage(AttributeTargets.Enum)]
public class SourceFontNameAttribute(string fontName) : Attribute
{
    public string FontName { get; } = fontName;
}
