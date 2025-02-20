using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace CommunityToolkit.WinForms.ChatUI;

internal static class BlazorWebViewExtensions
{
    public static string ToWebColor(this Color color) => 
        $"#{color.R:X2}{color.G:X2}{color.B:X2}";

    public static IServiceProvider? GetServiceProvider(this Control control)
    {
        if (control is null)
        {
            return null;
        }

        // Get the class with the Entry point for this app:
        var programType = Assembly.GetEntryAssembly()?.GetTypes()
            .FirstOrDefault(t => t.Name == "Program");

        if (programType == null)
        {
            return null;
        }

        // Get the first property which implements IServiceProvider:
        var serviceProviderProperty = programType?.GetProperties()
            .FirstOrDefault(p => typeof(IServiceProvider).IsAssignableFrom(p.PropertyType));

        if (serviceProviderProperty != null)
        {
            // Get the value of the property:
            var serviceProvider = serviceProviderProperty.GetValue(null) as IServiceProvider;
            return serviceProvider;
        }

        // Get the first property whose type implements IHost:
        var hostProperty = programType?.GetProperties()
            .FirstOrDefault(p => typeof(IHost).IsAssignableFrom(p.PropertyType));

        if (hostProperty != null)
        {
            // Get the value of the property:
            var host = hostProperty.GetValue(null) as IHost;
            return host?.Services;
        }

        return null;
    }
}

//' This code is commented out as per the request
//'Namespace WinForms.ControlConcepts
//'    Friend Module BlazorWebViewExtensions
//'        <System.Runtime.CompilerServices.Extension()>

//'        Public Function ToWebColor(ByVal color As Color) As String
//'            Return $"#{color.R:X2}{color.G:X2}{color.B:X2}"
//'        End Function

//'        <System.Runtime.CompilerServices.Extension()>
//'        Public Function GetServiceProvider(ByVal control As Control) As IServiceProvider
//'            If control Is Nothing Then
//'                Return Nothing
//'            End If

//'            ' Get the class with the Entry point for this app:
//'            Dim programType = Assembly.GetEntryAssembly()?.GetTypes().FirstOrDefault(Function(t) t.Name = "Program")

//'            If programType Is Nothing Then
//'                Return Nothing
//'            End If

//'            ' Get the first property which implements IServiceProvider:
//'            Dim serviceProviderProperty = programType?.GetProperties().FirstOrDefault(Function(p) GetType(IServiceProvider).IsAssignableFrom(p.PropertyType))

//'            If serviceProviderProperty IsNot Nothing Then
//'                ' Get the value of the property:
//'                Dim serviceProvider = TryCast(serviceProviderProperty.GetValue(Nothing), IServiceProvider)
//'                Return serviceProvider
//'            End If

//'            ' Get the first property whose type implements IHost:
//'            Dim hostProperty = programType?.GetProperties().FirstOrDefault(Function(p) GetType(IHost).IsAssignableFrom(p.PropertyType))

//'            If hostProperty IsNot Nothing Then
//'                ' Get the value of the property:
//'                Dim host = TryCast(hostProperty.GetValue(Nothing), IHost)
//'                Return host?.Services
//'            End If

//'            Return Nothing
//'        End Function
//'    End Module
//'End Namespace
