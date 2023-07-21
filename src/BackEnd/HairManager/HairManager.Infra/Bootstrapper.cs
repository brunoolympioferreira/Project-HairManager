using FluentMigrator.Runner;
using HairManager.Domain.Extension;
using HairManager.Domain.Repositories;
using HairManager.Domain.Repositories.Funcionario;
using HairManager.Domain.Repositories.Shared;
using HairManager.Domain.Repositories.Usuario;
using HairManager.Infra.AcessoRepositories;
using HairManager.Infra.AcessoRepositories.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HairManager.Infra;

public static class Bootstrapper
{
    public static void AddRepository(this IServiceCollection services, IConfiguration configuration)
    {
        AddContexto(services, configuration);
        AddUnityOfWork(services);
        AddRepositories(services);
    }

    private static void AddContexto(IServiceCollection services, IConfiguration configuration)
    {
        var versaoServidor = new MySqlServerVersion(new Version(8, 0, 30));
        var connectionString = configuration.GetConnectionComplete();

        services.AddDbContext<HairManagerContext>(options =>
        {
            options.UseMySql(connectionString, versaoServidor);
        });
    }

    private static void AddUnityOfWork(IServiceCollection services)
    {
        services.AddScoped<IUnityOfWork, UnityOfWork>();
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services
            .AddScoped<IUsuarioReadOnlyRepository, UsuarioRepository>()
            .AddScoped<IUsuarioWriteOnlyRepository, UsuarioRepository>()
            .AddScoped<IUsuarioUpdateOnlyRepository, UsuarioRepository>()

            .AddScoped<IEnderecoWriteOnlyRepository, EnderecoRepository>()

            .AddScoped<IFuncionarioWriteOnlyRepository, FuncionarioRepository>()
            .AddScoped<IFuncionarioReadOnlyRepository, FuncionarioRepository>()
            .AddScoped<IFuncionarioUpdateOnlyRepository, FuncionarioRepository>();
    }
}
