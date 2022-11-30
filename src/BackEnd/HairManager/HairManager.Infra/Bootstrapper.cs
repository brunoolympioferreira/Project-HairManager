using FluentMigrator.Runner;
using HairManager.Domain.Extension;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HairManager.Infra;

public static class Bootstrapper
{
    public static void AddRepository(this IServiceCollection services, IConfiguration configuration)
    {
        AddFluentMigrator(services, configuration);
    }

    private static void AddFluentMigrator(IServiceCollection services, IConfiguration configuration)
    {
        services.AddFluentMigratorCore().ConfigureRunner(c =>
            c.AddMySql5()
            .WithGlobalConnectionString(configuration.GetConnectionComplete())
            .ScanIn(Assembly.Load("HairManager.Infra")).For.All());
    }
}
