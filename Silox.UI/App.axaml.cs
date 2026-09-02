using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;
using Silox.Data.Interfaces;
using Silox.Service;
using Silox.Service.DBContexts;
using Silox.Service.Services.EArhivaServices;
using Silox.UI.ViewModels;
using Silox.UI.Views;
using Silox.UI.Views.Earhiva;
using Silox.UI.Views.Login;

namespace Silox.UI;

public partial class App : Application
{
    private static IHost Host { get; set; } = null!;

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        Host = ConfigureHost();
        Host.Start();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var loginWindow = Host.Services.GetRequiredService<LoginWindow>();

            desktop.MainWindow = loginWindow;
            desktop.ShutdownRequested += async (s, e) =>
            {
                await Host.StopAsync();
                Host.Dispose();
            };

            loginWindow.Closed += (_, _) => { ShowMainWindow(desktop); };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private IHost ConfigureHost()
    {
        return Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, config) =>
            {
                config.SetBasePath(AppContext.BaseDirectory);
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((h, s) => ConfigureServices(s))
            .Build();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IConnectionStringResolver, ConnectionStringResolver>();
        services.AddDbContext<EArhivaDbContext>((sp, options) =>
        {
            var resolver = sp.GetRequiredService<IConnectionStringResolver>();
            var connectionString = resolver.GetConnectionString("earhiva");

            options.UseNpgsql(connectionString);
        });

        services.AddScoped<IEArhivaService, EArhivaService>();
        services.AddTransient<EArhivaViewModel>();
        services.AddTransient<EArhivaView>();

        services.AddTransient<MainViewModel>();
        services.AddTransient<MainWindow>();

        services.AddTransient<LoginViewModel>();
        services.AddTransient<LoginWindow>();
    }

    private void ShowMainWindow(
        IClassicDesktopStyleApplicationLifetime desktop)
    {
        var mainWindow = Host.Services.GetRequiredService<MainWindow>();

        desktop.MainWindow = mainWindow;
        mainWindow.Show();
    }

    // private async void CheckDbConnection()
    // {
    //     try
    //     {
    //         using (var scope = Host.Services.CreateScope())
    //         {
    //             var dbContext = scope.ServiceProvider.GetRequiredService<EArhivaDbContext>();
    //             await dbContext.Database.OpenConnectionAsync();
    //             Console.WriteLine("✅ Connected successfully!");
    //             await dbContext.Database.CloseConnectionAsync();
    //         }
    //     }
    //     catch (NpgsqlException ex)
    //     {
    //         Console.WriteLine($"❌ PostgreSQL Error Code {ex.SqlState}: {ex.Message}");
    //     }
    //     catch (Exception ex)
    //     {
    //         Console.WriteLine($"❌ General Error: {ex.Message}");
    //     }
    // }
}