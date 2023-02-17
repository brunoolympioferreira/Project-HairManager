using FluentAssertions;
using HairManager.Application.Services.Usuario.Login;
using HairManager.Exceptions.ExceptionsBase;
using System;
using System.Linq;
using System.Threading.Tasks;
using UtilsForTests.Criptografia;
using UtilsForTests.Entidades;
using UtilsForTests.Repositories;
using UtilsForTests.Token;
using Xunit;

namespace Business.Test.Usuario.Login;
public class LoginServiceTest
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        (var usuario, var senha) = UsuarioBuilder.Construir();

        var service = CriarService(usuario);

        var response = await service.Executar(new HairManager.Comunication.Requests.RequestLoginDTO
        {
            Email = usuario.Email,
            Senha = senha
        });

        response.Should().NotBeNull();
        response.Nome.Should().Be(usuario.Nome);
        response.Token.Should().NotBeNullOrWhiteSpace();

    }

    [Fact]
    public async Task Validar_Erro_Email_Invalido()
    {
        (var usuario, var senha) = UsuarioBuilder.Construir();

        var service = CriarService(usuario);

        Func<Task> acao = async () =>
        {
            await service.Executar(new HairManager.Comunication.Requests.RequestLoginDTO
            {
                Email = "email@invalido.com",
                Senha = senha
            });
        };

        await acao.Should().ThrowAsync<LoginInvalidoException>()
            .Where(ex => ex.Message.Equals(ResourceMensagensDeErro.LOGIN_INVALIDO));
    }

    [Fact]
    public async Task Validar_Erro_Senha_Invalido()
    {
        (var usuario, var senha) = UsuarioBuilder.Construir();

        var service = CriarService(usuario);

        Func<Task> acao = async () =>
        {
            await service.Executar(new HairManager.Comunication.Requests.RequestLoginDTO
            {
                Email = usuario.Email,
                Senha = "senhainvalida"
            });
        };

        await acao.Should().ThrowAsync<LoginInvalidoException>()
            .Where(ex => ex.Message.Equals(ResourceMensagensDeErro.LOGIN_INVALIDO));
    }

    [Fact]
    public async Task Validar_Erro_Email_Senha_Invalido()
    {
        (var usuario, var senha) = UsuarioBuilder.Construir();

        var service = CriarService(usuario);

        Func<Task> acao = async () =>
        {
            await service.Executar(new HairManager.Comunication.Requests.RequestLoginDTO
            {
                Email = "email@invalido.com",
                Senha = "senhainvalida"
            });
        };

        await acao.Should().ThrowAsync<LoginInvalidoException>()
            .Where(ex => ex.Message.Equals(ResourceMensagensDeErro.LOGIN_INVALIDO));
    }

    private LoginService CriarService(HairManager.Domain.Entities.Usuario usuario)
    {
        var repositoryReadOnly = UsuarioReadOnlyRepositoryBuilder.Instancia().RecuperarPorEmailSenha(usuario).Construir();
        var encriptador = EncriptadorDeSenhaBuilder.Instancia();
        var token = TokenControllerBuilder.Instancia();

        return new LoginService(repositoryReadOnly, encriptador, token);
    }
}


