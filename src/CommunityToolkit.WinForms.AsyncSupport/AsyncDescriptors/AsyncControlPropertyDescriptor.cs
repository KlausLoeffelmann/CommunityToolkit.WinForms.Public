using System.ComponentModel;

namespace CommunityToolkit.WinForms.AsyncSupport;

public class AsyncControlPropertyDescriptor(PropertyDescriptor original, Control control) : PropertyDescriptor(original)
{
    public override object? GetValue(object? component)
    {
        if (control.InvokeRequired)
        {
            return control.Invoke(() => original.GetValue(component));
        }
        return original.GetValue(component);
    }

    public override void SetValue(object? component, object? value)
    {
        if (control.InvokeRequired)
        {
            control.Invoke(() => original.SetValue(component, value));
        }
        else
        {
            original.SetValue(component, value);
        }
    }

    // Required overrides that delegate to the original descriptor
    public override Type ComponentType => original.ComponentType;
    public override bool IsReadOnly => original.IsReadOnly;
    public override Type PropertyType => original.PropertyType;
    public override bool CanResetValue(object component) => original.CanResetValue(component);
    public override void ResetValue(object component) => original.ResetValue(component);
    public override bool ShouldSerializeValue(object component) => original.ShouldSerializeValue(component);
}
