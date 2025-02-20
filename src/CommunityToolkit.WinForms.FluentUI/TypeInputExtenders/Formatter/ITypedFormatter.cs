using System.ComponentModel;

namespace CommunityToolkit.WinForms.FluentUI.Controls.TypedInputExtenders;

[TypeConverter(typeof(TypedFormatterTypeConverter))]
public interface ITypedFormatter<T>
    : INotifyPropertyChanged
{
    Task<T?> ConvertToValueAsync(string? stringValue, CancellationToken token);

    Task<string?> ConvertToDisplayAsync(T? value, CancellationToken token);

    Task<string?> InitializeEditedValueAsync(T? value, CancellationToken token);
}
