using System.Globalization;

namespace CommunityToolkit.WinForms.ComponentModel;

public interface IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture);
    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture);
}
