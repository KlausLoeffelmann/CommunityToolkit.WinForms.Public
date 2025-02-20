using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace CommunityToolkit.WinForms.AsyncSupport;

public class ComponentEventTypeConverter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType) 
        => sourceType == typeof(string);

    public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
    {
        if (value is string eventName 
            && context?.Instance is AsyncCommandComponent asyncCommandComponent 
            && asyncCommandComponent.EventSender != null)
        {
            Type eventSenderType = asyncCommandComponent.EventSender.GetType();
            EventInfo? eventInfo = eventSenderType.GetEvent(eventName);

            return eventInfo;
        }

        return base.ConvertFrom(context, culture, value);
    }

    public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType) 
        => destinationType == typeof(string);

    public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType) 
        => value is EventInfo eventInfo && destinationType == typeof(string)
            ? eventInfo.Name
            : base.ConvertTo(context, culture, value, destinationType);

    public override StandardValuesCollection? GetStandardValues(ITypeDescriptorContext? context)
    {
        if (context?.Instance is AsyncCommandComponent asyncCommandComponent 
            && asyncCommandComponent.EventSender != null)
        {
            Type eventSenderType = asyncCommandComponent.EventSender.GetType();
            IEnumerable<EventInfo> events = eventSenderType.GetEvents();

            return new StandardValuesCollection(events.Select(e => e.Name).ToList());
        }

        return base.GetStandardValues(context);
    }

    public override bool GetStandardValuesSupported(ITypeDescriptorContext? context) 
        => true;
}
