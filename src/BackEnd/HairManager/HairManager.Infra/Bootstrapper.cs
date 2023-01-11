using FluentMigrator.Runner;
using HairManager.Domain.Extension;
using HairManager.Domain.Repositories;
using HairManager.Infra.AcessoRepositories;
using HairManager.Infra.AcessoRepositories.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using System.Reflection;

namespace HairManager.Infra;

public static class Bootstrapper
{
    public static void AddRepository(this IServiceCollection services, IConfiguration configuration)
    {
        AddFluentMigrator(services, configuration);

        AddContexto(services, configuration);
        AddUnityOfWork(services);
        AddRepositories(services);
    }

    private static void AddFluentMigrator(IServiceCollection services, IConfiguration configuration)
    {
        _ = bool.TryParse(configuration.GetSection("Configuracoes:BancoDeDadosInMemory").Value, out bool bancoDeDadosInMemory);

        if (!bancoDeDadosInMemory)
        {
            services.AddFluentMigratorCore().ConfigureRunner(c =>
            c.AddMySql5()
            .WithGlobalConnectionString(configuration.GetConnectionComplete())
            .ScanIn(Assembly.Load("HairManager.Infra")).For.All());
        }        
    }

    private static void AddContexto(IServiceCollection services, IConfiguration configuration)
    {
        _ = bool.TryParse(configuration.GetSection("Configuracoes:BancoDeDadosInMemory").Value, out bool bancoDeDadosInMemory);

        if (!bancoDeDadosInMemory)
        {
            var versaoServidor = new MySqlServerVersion(new Version(8, 0, 30));
            var connectionString = configuration.GetConnectionComplete();

            services.AddDbContext<HairManagerContext>(options =>
            {
                options.UseMySql(connectionString, versaoServidor);
            });
        }   
    }

    private static void AddUnityOfWork(IServiceCollection services)
    {
        services.AddScoped<IUnityOfWork, UnityOfWork>();
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services
            .AddScoped<IUsuarioReadOnlyRepository, UsuarioRepository>()
            .AddScoped<IUsuarioWriteOnlyRepository, UsuarioRepository>();
    }
}
