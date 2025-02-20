using Microsoft.Extensions.Hosting;

namespace Chatty;

internal static class Program
{
    public static WinFormsHost WinFormsHost { get; private set; } = null!;

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.SetColorMode(SystemColorMode.Dark);
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

        // WinFormsHost is using IHost of Microsoft.Extensions.Hosting and
        // provide DI, so we can easily communicate between different parts of the application.
        // for example between a Blazor component and a WinForms form.
        WinFormsHost = WinFormsHost.Initialize(
            startFormType: typeof(FrmMain));

        WinFormsHost.Start();
    }
}
