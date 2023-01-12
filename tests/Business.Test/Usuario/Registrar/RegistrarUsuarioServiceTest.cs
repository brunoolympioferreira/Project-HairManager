using FluentAssertions;
using HairManager.Application.Services.Usuario.Registrar;
using HairManager.Exceptions.ExceptionsBase;
using System;
using System.Threading.Tasks;
using UtilsForTests.Criptografia;
using UtilsForTests.Mapper;
using UtilsForTests.Repositories;
using UtilsForTests.Requests;
using UtilsForTests.Token;
using Xunit;

namespace Business.Test.Usuario.Registrar;
public class RegistrarUsuarioServiceTest
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        var request = RequestRegistrarUsuarioBuilder.Construir();
        request.ConfirmeSenha = request.Senha;

        var service = CriarService();

        var response = await service.Executar(request);

        response.Should().NotBeNull();
        response.Token.Should().NotBeNullOrWhiteSpace();
        response.Nome.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task Validar_Erro_Email_Ja_Registrado()
    {
        var request = RequestRegistrarUsuarioBuilder.Construir();
        request.ConfirmeSenha = request.Senha;

        var service = CriarService(request.Email);

        Func<Task> acao = async () => { await service.Executar(request); };

        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
            .Where(exception => exception.MensagensDeErro.Count == 1 &&
                exception.MensagensDeErro.Contains(ResourceMensagensDeErro.EMAIL_JA_CADASTRADO));
    }

    [Fact]
    public async Task Validar_Erro_Email_Vazio()
    {
        var request = RequestRegistrarUsuarioBuilder.Construir();
        request.ConfirmeSenha = request.Senha;
        request.Email = string.Empty;

        var service = CriarService();

        Func<Task> acao = async () => { await service.Executar(request); };

        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
            .Where(exception => exception.MensagensDeErro.Count == 1 &&
                exception.MensagensDeErro.Contains(ResourceMensagensDeErro.EMAIL_USUARIO_EMBRANCO));
    }

    private RegistrarUsuarioService CriarService(string email = "")
    {
        var repositoryReadOnly = UsuarioReadOnlyRepositoryBuilder.Instancia().ExisteUsuarioComEmail(email).Construir();
        var repository = UsuarioWriteOnlyRepositoryBuilder.Instancia().Construir();
        var mapper = MapperBuilder.Instancia();
        var unityOfWork = UnityOfWorkBuilder.Instancia().Construir();
        var encriptador = EncriptadorDeSenhaBuilder.Instancia();
        var token = TokenControllerBuilder.Instancia();

        return new RegistrarUsuarioService(repositoryReadOnly, repository, mapper, unityOfWork, encriptador, token);
    }
}
