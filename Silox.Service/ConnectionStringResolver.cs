using Microsoft.Extensions.Configuration;
using Silox.Data.Interfaces;

namespace Silox.Service
{
    public class ConnectionStringResolver(IConfiguration configuration) : IConnectionStringResolver
    {
        public string GetConnectionString(string dbName)
        {
            return configuration.GetConnectionString(dbName)
                   ?? throw new InvalidOperationException($"Connection string '{dbName}' was not found.");
        }
    }
}