using System.ComponentModel;

namespace CommunityToolkit.WinForms.AsyncSupport;

public class AsyncTypeDescriptor(ICustomTypeDescriptor? parent, Control control) : CustomTypeDescriptor(parent)
{
    public override PropertyDescriptorCollection GetProperties()
    {
        PropertyDescriptorCollection originalProps = base.GetProperties();
        PropertyDescriptor[] newProps = new PropertyDescriptor[originalProps.Count];

        for (int i = 0; i < originalProps.Count; i++)
        {
            PropertyDescriptor prop = originalProps[i];
            newProps[i] = new AsyncControlPropertyDescriptor(prop, control);
        }

        return new PropertyDescriptorCollection(newProps);
    }
}
