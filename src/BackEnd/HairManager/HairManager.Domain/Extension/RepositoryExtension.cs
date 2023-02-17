using Microsoft.Extensions.Configuration;

namespace HairManager.Domain.Extension;

public static class RepositoryExtension
{
    public static string GetDatabaseName(this IConfiguration configurationManager)
    {
        var nameDatabase = configurationManager.GetConnectionString("NomeDatabase");

        return nameDatabase;
    }

    public static string GetConnection(this IConfiguration configurationManager)
    {
        var connection = configurationManager.GetConnectionString("Conexao");

        return connection;
    }

    public static string GetConnectionComplete(this IConfiguration configurationManager)
    {
        var nameDatabase = configurationManager.GetDatabaseName();
        var connection = configurationManager.GetConnection();

        return $"{connection}Database={nameDatabase}";
    }
}
