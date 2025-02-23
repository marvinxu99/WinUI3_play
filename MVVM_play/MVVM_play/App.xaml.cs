using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;
using MVVM_play.Models;
using MVVM_play.Services;
using MVVM_play.ViewModels;
using MVVM_play.Views;
using System;
using System.Diagnostics;
using System.IO;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MVVM_play;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : Application
{
    private Window? m_window;
    private static IHost? _host;

    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        this.InitializeComponent();

        LoadEnvironmentVariables(); // Load .env variables at startup

        _host = CreateHost();

        //Seed Database if needed
        //DbInitializer.Initialize();
    }

    private static IHost CreateHost()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                // Register DbContext
                //services.AddDbContext<DatabaseContext>();
                services.AddDbContext<DatabaseContext>();

                // Register DbContext
                services.AddDbContext<LoggingDbContext>();

                // Register LoggingService
                services.AddSingleton<LoggingService>();

                // Register services
                services.AddScoped<UserService>();

                // Register ViewModels
                services.AddScoped<UserViewModel>();

                // Register ViewModel as Scoped (New Instance Per Request)
                services.AddTransient<UserMergedViewModel>();

                // Register Page (View) - usually shold be transient
                services.AddTransient<DataGridMergedDataPage>();

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

    private static void LoadEnvironmentVariables()
    {
        //string envFilePath = Path.Combine(AppContext.BaseDirectory, ".env");
        string envFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MVVM_play");
        string envFilePath = Path.Combine(envFolderPath, ".env");

        // Ensure the folder exists
        if (!Directory.Exists(envFolderPath))
        {
            Directory.CreateDirectory(envFolderPath);
        }

        // Create a default .env file if it does not exist
        if (!File.Exists(envFilePath))
        {
            File.WriteAllText(envFilePath, "EMAIL_USERNAME=\nEMAIL_PASSWORD=\n");  // Empty file with placeholders
            System.Diagnostics.Debug.WriteLine($"Created default .env file at: {envFilePath}");
        }

        // Load environment variables from the .env file
        var lines = File.ReadAllLines(envFilePath);
        foreach (var line in lines)
        {
            var parts = line.Split('=', 2);
            if (parts.Length == 2)
            {
                Environment.SetEnvironmentVariable(parts[0], parts[1]);
            }
        }
        System.Diagnostics.Debug.WriteLine(".env file loaded successfully.");

    }

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
    {
        m_window = new MainWindow();

        UnhandledException += App_UnhandledException;

        m_window.Activate();
    }

    private void App_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    {
        Debug.WriteLine($"Unhandled exception occurred: {e.Exception}");
        Debug.WriteLine($"Message: {e.Message}");
        Debug.WriteLine($"StackTrace: {e.Exception?.StackTrace}");

        // Prevent the app from crashing if appropriate
        e.Handled = true;
    }


}
