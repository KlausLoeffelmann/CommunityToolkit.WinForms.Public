using System.ComponentModel;

namespace CommunityToolkit.WinForms.FluentUI.Controls.TypedInputExtenders;

public interface ITypedFormatterComponent : IComponent, ISupportInitialize
{
    event EventHandler NotifyEndInit;

    Task<bool> TryConvertToValueAsync(TextBox textBox, string? stringValue, CancellationToken token);

    Task<string?> ConvertToDisplayAsync(TextBox textBox, CancellationToken token);

    Task<string?> InitializeEditedValueAsync(TextBox textBox, CancellationToken token);

    object? GetValue(TextBox textBox);

    Task<object?> TryGetValueAsync(string text, CancellationToken token);

    void SetValue(TextBox textBox, object? value);

    object? GetDefaultValue();
}
