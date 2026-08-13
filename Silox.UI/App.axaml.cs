using System;
using System.IO;
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

namespace Silox.UI;

public partial class App : Application
{
    private static IHost? Host { get; set; }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, config) =>
            {
                config.SetBasePath(AppContext.BaseDirectory);
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((h, s) => ConfigureServices(s))
            .Build();

        Host.Start();

        CheckDbConnection();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = Host.Services.GetRequiredService<EArhiva>();
            desktop.ShutdownRequested += async (s, e) =>
            {
                await Host.StopAsync();
                Host.Dispose();
            };
        }

        base.OnFrameworkInitializationCompleted();
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
        services.AddTransient<EArhiva>();
    }

    private async void CheckDbConnection()
    {
        try
        {
            using (var scope = Host.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<EArhivaDbContext>();
                await dbContext.Database.OpenConnectionAsync();
                Console.WriteLine("✅ Connected successfully!");
                await dbContext.Database.CloseConnectionAsync();
            }
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine($"❌ PostgreSQL Error Code {ex.SqlState}: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ General Error: {ex.Message}");
        }
    }
}