using HairManager.Domain.Entities;
using HairManager.Infra.AcessoRepositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace WebApi.Test;
public class HairManagerApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    private Usuario _usuario;
    private string _senha;
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Test")
            .ConfigureServices(services =>
            {
                ServiceDescriptor descritor = services.SingleOrDefault(d => d.ServiceType == typeof(HairManagerContext));
                if (descritor is not null)
                    services.Remove(descritor);

                ServiceProvider provider = services.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

                services.AddDbContext<HairManagerContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                    options.UseInternalServiceProvider(provider);
                });

                ServiceProvider serviceProvider = services.BuildServiceProvider();

                using IServiceScope scope = serviceProvider.CreateScope();
                IServiceProvider scopeService = scope.ServiceProvider;

                HairManagerContext database = scopeService.GetRequiredService<HairManagerContext>();

                database.Database.EnsureDeleted();

                (_usuario, _senha) = ContextSeedInMemory.Seed(database);
            });
    }

    public Usuario RecuperarUsuario()
    {
        return _usuario;
    }

    public string RecuperarSenha()
    {
        return _senha;
    }
}
