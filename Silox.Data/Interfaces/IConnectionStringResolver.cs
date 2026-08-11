namespace Silox.Data.Interfaces;

public interface IConnectionStringResolver
{
    string GetConnectionString(string dbName);
}