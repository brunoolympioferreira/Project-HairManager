using HairManager.Application.Services.Usuario.Registrar;
using HairManager.Application.Utils.Criptografia;
using HairManager.Application.Utils.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HairManager.Application;
public static class Bootstrapper
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        AdicionarChaveAdiconalSenha(services, configuration);
        AdicionarChaveAdiconalConfirmeSenha(services, configuration);
        AdicionarTokenJWT(services, configuration);

        services.AddScoped<IRegistrarUsuarioService, RegistrarUsuarioService>();
    }

    private static void AdicionarChaveAdiconalSenha(IServiceCollection services, IConfiguration configuration)
    {
        var section = configuration.GetRequiredSection("Configuracoes:ChaveAdicionalSenha");

        services.AddScoped(option => new EncriptadorDeSenha(section.Value));
    }

    private static void AdicionarChaveAdiconalConfirmeSenha(IServiceCollection services, IConfiguration configuration)
    {
        var section = configuration.GetRequiredSection("Configuracoes:ChaveAdicionalConfirmarSenha");

        services.AddScoped(option => new EncriptadorDeSenha(section.Value));
    }

    private static void AdicionarTokenJWT(IServiceCollection services, IConfiguration configuration)
    {
        var sectionTempoDeVida = configuration.GetRequiredSection("Configuracoes:TempoVidaToken");
        var sectionKey = configuration.GetRequiredSection("Configuracoes:ChaveToken");

        services.AddScoped(option => new TokenController(int.Parse(sectionTempoDeVida.Value), sectionKey.Value));
    }
}
