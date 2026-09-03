using System;
using System.Threading.Tasks;
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
using Silox.Service.Extensions;
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

        // CheckDatabases();

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
        services.AddDatabaseServices();

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

    private async Task CheckDatabases()
    {
        using var scope = Host.Services.CreateScope();

        var earhiva = scope.ServiceProvider
            .GetRequiredService<EArhivaDbContext>();

        var garson = scope.ServiceProvider
            .GetRequiredService<GarsonDbContext>();

        Console.WriteLine(
            $"E-Arhiva: {(await earhiva.Database.CanConnectAsync() ? "Connected" : "X")}");

        Console.WriteLine(
            $"Garson: {(await garson.Database.CanConnectAsync() ? "Connected" : "X")}");
    }
}