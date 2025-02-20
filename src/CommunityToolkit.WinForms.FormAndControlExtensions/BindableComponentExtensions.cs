using CommunityToolkit.WinForms.ComponentModel;

using System.Globalization;

namespace CommunityToolkit.WinForms.Extensions.FormAndControlExtensions;

public static class BindableComponentExtensions
{
    /// <summary>
    ///  Adds a value converter to an existing binding on a bindable component.
    /// </summary>
    /// <param name="bindableComponent">The bindable component to which the converter is added.</param>
    /// <param name="propertyName">The name of the property that is bound.</param>
    /// <param name="valueConverter">The value converter to be added to the binding.</param>
    /// <returns>The binding with the added value converter.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="propertyName"/> or <paramref name="valueConverter"/> is null.</exception>
    /// <exception cref="InvalidOperationException">Thrown when no binding is found for the specified property.</exception>
    public static Binding AddBindingConverter(
        this IBindableComponent bindableComponent,
        string propertyName,
        IValueConverter valueConverter)
    {
        ArgumentNullException.ThrowIfNull(propertyName, nameof(propertyName));
        ArgumentNullException.ThrowIfNull(valueConverter, nameof(valueConverter));

        if (bindableComponent.DataBindings[propertyName] is not Binding binding)
        {
            throw new InvalidOperationException($"No binding found for property '{propertyName}'.");
        }

        binding.Parse += Binding_Parse;
        binding.Format += Binding_Format;

        BindingManagerBase? managerBase = binding.BindingManagerBase;

        bindableComponent.Disposed += Control_Disposed;
        return binding;

        void Binding_Format(object? sender, ConvertEventArgs e)
        {
            e.Value = valueConverter.Convert(e.Value, e.DesiredType!, null, CultureInfo.CurrentCulture);
        }

        void Binding_Parse(object? sender, ConvertEventArgs e)
        {
            e.Value = valueConverter.ConvertBack(e.Value, e.DesiredType!, null, CultureInfo.CurrentCulture);
        }

        void Control_Disposed(object? sender, EventArgs e)
        {
            binding.Parse -= Binding_Parse;
            binding.Format -= Binding_Format;
        }
    }

    public static void RemoveBinding(this IBindableComponent bindableComponent, string PropertyName)
    {
        ArgumentNullException.ThrowIfNull(PropertyName, nameof(PropertyName));

        // TODO: This is not robust. We need to pass the source we want to unbind, and then find the binding that matches the source.
        if (bindableComponent.DataBindings[PropertyName] is not Binding binding)
        {
            throw new InvalidOperationException($"No binding found for property '{PropertyName}'.");
        }

        bindableComponent.DataBindings.Remove(binding);
    }
}
