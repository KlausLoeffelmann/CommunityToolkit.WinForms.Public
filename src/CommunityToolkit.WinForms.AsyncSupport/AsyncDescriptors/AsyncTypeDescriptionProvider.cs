using System.ComponentModel;

namespace CommunityToolkit.WinForms.AsyncSupport;

public class AsyncTypeDescriptionProvider(Control component) : TypeDescriptionProvider
{
    public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object? instance) 
        => new AsyncTypeDescriptor(TypeDescriptor.GetProvider(objectType).GetTypeDescriptor(objectType, instance), component);
}
