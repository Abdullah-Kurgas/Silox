using System;
using System.Diagnostics;
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
using Silox.UI.Views;

namespace Silox.UI;

public partial class App : Application
{
    public static IHost Host { get; private set; }
    
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory());
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<IConnectionStringResolver, ConnectionStringResolver>();
                services.AddDbContext<EArhivaDbContext>((sp, options) =>
                {
                    var resolver = sp.GetRequiredService<IConnectionStringResolver>();
                    var connectionString = resolver.GetConnectionString("earhiva");

                    options.UseNpgsql(connectionString);
                });
            })
            .Build();
        
        Host.Start();
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindow(),
            };
        }

        base.OnFrameworkInitializationCompleted();
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
            // Specific PostgreSQL Server Error (e.g., Wrong Password, DB doesn't exist)
            Console.WriteLine($"❌ PostgreSQL Error Code {ex.SqlState}: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Network or File Error (e.g., Port blocked, Appsettings missing)
            Console.WriteLine($"❌ General Error: {ex.Message}");
        }
    }
}