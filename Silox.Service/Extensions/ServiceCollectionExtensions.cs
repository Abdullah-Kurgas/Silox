using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Silox.Data.Interfaces;
using Silox.Service.DBContexts;

namespace Silox.Service.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabaseServices(
        this IServiceCollection services)
    {
        services.AddDbContext<EArhivaDbContext>((sp, options) =>
        {
            var resolver = sp.GetRequiredService<IConnectionStringResolver>();
            var connectionString = resolver.GetConnectionString("earhiva");

            options.UseNpgsql(connectionString);
        });

        services.AddDbContext<GarsonDbContext>((sp, options) =>
        {
            var resolver = sp.GetRequiredService<IConnectionStringResolver>();
            var connectionString = resolver.GetConnectionString("garson");

            options.UseFirebird(connectionString);
        });

        return services;
    }
}