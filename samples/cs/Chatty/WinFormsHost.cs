using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Chatty;

/// <summary>
///  Represents a host for a WinForms application.
/// </summary>
public class WinFormsHost : IHost
{
    private bool disposedValue;
    private readonly IHost _innerHost;

    private static IHost? s_host;

    /// <summary>
    ///  Initializes a new instance of the <see cref="WinFormsHost"/> class.
    /// </summary>
    /// <param name="host">The inner host.</param>
    /// <param name="colorMode">The system color mode.</param>
    private WinFormsHost(
        IHost host)
    {
        _innerHost = host;
    }

    /// <summary>
    ///  Gets the services provided by the host.
    /// </summary>
    public IServiceProvider Services => _innerHost.Services;

    /// <summary>
    ///  Initializes the WinForms host.
    /// </summary>
    /// <param name="startFormType">The type of the start form.</param>
    /// <param name="colorMode">The system color mode. Default is <see cref="SystemColorMode.Classic"/>.</param>
    /// <returns>The initialized <see cref="WinFormsHost"/>.</returns>
    public static WinFormsHost Initialize(
        Type startFormType)
    {
        if (s_host is not null)
        {
            s_host.Services.GetRequiredService<ILogger<WinFormsHost>>().LogWarning("Host already initialized");
            s_host.Dispose();
        }

        var builder = new HostBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddWindowsFormsBlazorWebView();
                services.AddBlazorWebView();
                services.AddLogging(configure => configure.AddConsole());
                services.AddTransient(typeof(Form), startFormType);
            });

        var host = builder.Build();
        Application.ApplicationExit += (sender, args) => host.Dispose();

        s_host = new WinFormsHost(host);
        return (WinFormsHost)s_host;
    }

    /// <summary>
    ///  Starts the WinForms host asynchronously.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task StartAsync(CancellationToken cancellationToken = default)
    {
        var form = Services.GetRequiredService<Form>();
        Application.Run(form);

        return Task.CompletedTask;
    }

    /// <summary>
    ///  Stops the WinForms host asynchronously.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task StopAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///  Releases the resources used by <see cref="WinFormsHost"/>.
    /// </summary>
    /// <param name="disposing">A value indicating whether the object is being disposed.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _innerHost.Dispose();
            }

            disposedValue = true;
        }
    }

    /// <summary>
    ///  Releases the resources used by <see cref="WinFormsHost"/>.
    /// </summary>
    public void Dispose()
    {
        // Do not change this code.
        // Put cleanup code in the 'Dispose(bool disposing)' method.
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
