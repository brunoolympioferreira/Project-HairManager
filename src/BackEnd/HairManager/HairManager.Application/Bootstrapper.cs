using HairManager.Application.Services.Endereco;
using HairManager.Application.Services.Funcionario.Adicionar;
using HairManager.Application.Services.Funcionario.Atualizar;
using HairManager.Application.Services.Funcionario.Listar;
using HairManager.Application.Services.Funcionario.RecuperarPorId;
using HairManager.Application.Services.Usuario.AlterarSenha;
using HairManager.Application.Services.Usuario.Login;
using HairManager.Application.Services.Usuario.RecuperarPerfil;
using HairManager.Application.Services.Usuario.Registrar;
using HairManager.Application.Utils.Criptografia;
using HairManager.Application.Utils.Token;
using HairManager.Application.Utils.UsuarioLogado;
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
        AdicionarServices(services);
        AdicionarUsuarioLogado(services);
    }

    private static void AdicionarUsuarioLogado(IServiceCollection services)
    {
        services.AddScoped<IUsuarioLogado, UsuarioLogado>();
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

    private static void AdicionarServices(IServiceCollection services)
    {
        services
            .AddScoped<IRegistrarUsuarioService, RegistrarUsuarioService>()
            .AddScoped<ILoginService, LoginService>()
            .AddScoped<IRecuperarPerfilService, RecuperarPerfilService>()
            .AddScoped<IAlterarSenhaService, AlterarSenhaService>()
            .AddScoped<IAdicionarFuncionarioService, AdicionarFuncionarioService>()
            .AddScoped<IAdicionarFuncionarioService, AdicionarFuncionarioService>()
            .AddScoped<IEnderecoService, EnderecoService>()
            .AddScoped<IListarFuncionariosService, ListarFuncionariosService>()
            .AddScoped<IRecuperarFuncionarioPorIdService, RecuperarFuncionarioPorIdService>()
            .AddScoped<IAtualizarFuncionarioService, AtualizarFuncionarioService>();
    }
}
