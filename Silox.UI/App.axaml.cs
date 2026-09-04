using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Silox.Data.Interfaces;
using Silox.Service;
using Silox.Service.DBContexts;
using Silox.Service.Extensions;
using Silox.Service.Services;
using Silox.Service.Services.Authorization;
using Silox.Service.Services.EArhivaServices;
using Silox.UI.Components.Sidebar;
using Silox.UI.ViewModels;
using Silox.UI.Views;
using Silox.UI.Views.Earhiva;
using Silox.UI.Views.Login;

namespace Silox.UI;

public class App : Application
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
            // desktop.ShutdownRequested += async (s, e) =>
            // {
            //     await Host.StopAsync();
            //     Host.Dispose();
            // };

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
        services.AddSingleton<UserSession>();
        services.AddDatabaseServices();

        // Services
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<IPermissionService, PermissionService>();
        services.AddScoped<IEArhivaService, EArhivaService>();

        // View models
        services.AddTransient<EArhivaViewModel>();
        services.AddTransient<MainViewModel>();
        services.AddTransient<LoginViewModel>();
        services.AddTransient<SidebarViewModel>();

        // Windows
        services.AddTransient<EArhivaView>();
        services.AddTransient<MainWindow>();
        services.AddTransient<LoginWindow>();
        services.AddTransient<Sidebar>();
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