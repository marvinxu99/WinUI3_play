using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;
using MVVM_play.Models;
using MVVM_play.Services;
using MVVM_play.ViewModels;
using MVVM_play.Views;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MVVM_play;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : Application
{
    private static Microsoft.Extensions.Hosting.IHost? _host;

    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        this.InitializeComponent();
        _host = CreateHost();
    }

    private static IHost CreateHost()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                // Register DbContext
                services.AddDbContext<DatabaseContext>();

                // Register DbContext
                services.AddDbContext<LoggingDbContext>();

                // Register LoggingService
                services.AddSingleton<LoggingService>();

                // Register services
                services.AddSingleton<UserService>();

                // Register ViewModels
                services.AddSingleton<UserViewModel>();

                // Register ViewModel as Scoped (New Instance Per Request)
                services.AddSingleton<UserMergedViewModel>();

                // Register Page (View) as Scoped
                services.AddSingleton<DataGridMergedDataPage>();

            })
            .Build();
    }
    public static T GetService<T>() where T : class
    {
        if (_host?.Services == null)
        {
            throw new InvalidOperationException("Host has not been initialized yet.");
        }
        return _host.Services.GetRequiredService<T>();
    }

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
    {
        m_window = new MainWindow();
        //UnhandledException += App_UnhandledException;
        m_window.Activate();
    }

    //private void App_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    //{
    //    Debug.WriteLine($"Unhandled exception occurred: {e.Exception}");
    //    Debug.WriteLine($"Message: {e.Message}");
    //    Debug.WriteLine($"StackTrace: {e.Exception?.StackTrace}");

    //    // Prevent the app from crashing if appropriate
    //    e.Handled = true;
    //}

    private Window? m_window;
}
