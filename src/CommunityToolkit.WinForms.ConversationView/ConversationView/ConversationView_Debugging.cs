using Microsoft.Web.WebView2.Core;
using System.Diagnostics;

namespace CommunityToolkit.WinForms.ChatUI;

/// <summary>
///  Represents a custom conversation view control that extends 
///  the BlazorWebView class.
/// </summary>
public partial class ConversationView 
{
    private void WebView_NavigationStarting(object? sender, CoreWebView2NavigationStartingEventArgs e)
    {
        Debug.Print($"Navigation starting - URI:{e.Uri}");
    }

    private void CoreWebView2_DOMContentLoaded(object? sender, CoreWebView2DOMContentLoadedEventArgs e)
        => Debug.Print($"DOM content loaded - ID:{e.NavigationId}");

    private void WebView_NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
        => Debug.Print($"Navigation completed - success:{e.IsSuccess}");

    private void WebView_CoreWebView2InitializationCompleted(object? sender, CoreWebView2InitializationCompletedEventArgs e)
    {
        WebView.CoreWebView2.DOMContentLoaded += CoreWebView2_DOMContentLoaded;
        WebView.CoreWebView2.WebMessageReceived += CoreWebView2_WebMessageReceived;
        WebView.CoreWebView2.WebResourceRequested += CoreWebView2_WebResourceRequested;
    }

    private void CoreWebView2_WebResourceRequested(object? sender, CoreWebView2WebResourceRequestedEventArgs e)
    {
        Debug.Print($"Web resource requested: {e.Request.Uri}");
    }

    private void CoreWebView2_WebMessageReceived(object? sender, CoreWebView2WebMessageReceivedEventArgs e)
    {
        // Debug.Print($"Web message received: {e.TryGetWebMessageAsString()}");
    }
}
