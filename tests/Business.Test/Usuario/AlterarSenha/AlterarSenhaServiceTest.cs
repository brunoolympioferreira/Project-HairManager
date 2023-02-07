using FluentAssertions;
using HairManager.Application.Services.Usuario.AlterarSenha;
using HairManager.Application.Utils.Criptografia;
using HairManager.Application.Utils.UsuarioLogado;
using HairManager.Comunication.Requests;
using HairManager.Domain.Repositories;
using HairManager.Domain.Repositories.Usuario;
using HairManager.Exceptions.ExceptionsBase;
using System;
using System.Threading.Tasks;
using UtilsForTests.Criptografia;
using UtilsForTests.Entidades;
using UtilsForTests.Repositories;
using UtilsForTests.Requests;
using UtilsForTests.UsuarioLogado;
using Xunit;

namespace Business.Test.Usuario.AlterarSenha;
public class AlterarSenhaServiceTest
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        (var usuario, var senha) = UsuarioBuilder.Construir();

        AlterarSenhaService service = CriarService(usuario);

        RequestAlterarSenhaDTO request = RequestAlterarSenhaUsuarioBuilder.Construir();
        request.SenhaAtual = senha;
        request.ConfirmeNovaSenha = request.NovaSenha;

        Func<Task> acao = async () =>
        {
            await service.Executar(request);
        };

        await acao.Should().NotThrowAsync();
    }

    [Fact]
    public async Task Validar_Erro_NovaSenha_EmBranco()
    {
        (var usuario, var senha) = UsuarioBuilder.Construir();

        AlterarSenhaService service = CriarService(usuario);

        Func<Task> acao = async () =>
        {
            await service.Executar(new RequestAlterarSenhaDTO
            {
                SenhaAtual = senha,
                NovaSenha = string.Empty
            });
        };

        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
            .Where(ex => ex.MensagensDeErro.Count == 1 && ex.MensagensDeErro.Contains(ResourceMensagensDeErro.SENHA_USUARIO_EMBRANCO));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public async Task Validar_Erro_SenhaAtual_Invalida(int tamanhoSenha)
    {
        (var usuario, var senha) = UsuarioBuilder.Construir();

        AlterarSenhaService service = CriarService(usuario);

        RequestAlterarSenhaDTO request = RequestAlterarSenhaUsuarioBuilder.Construir(tamanhoSenha);
        request.SenhaAtual = senha;
        request.ConfirmeNovaSenha = request.NovaSenha;

        Func<Task> acao = async () =>
        {
            await service.Executar(request);
        };

        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
            .Where(ex => ex.MensagensDeErro.Count == 1 && ex.MensagensDeErro.Contains(ResourceMensagensDeErro.SENHA_USUARIO_MINIMO_SEIS_CARACTERES));
    }

    private AlterarSenhaService CriarService(HairManager.Domain.Entities.Usuario usuario)
    {
        IUsuarioLogado usuarioLogado = UsuarioLogadoBuilder.Instancia().RecuperarUsuario(usuario).Construir();
        IUsuarioUpdateOnlyRepository repository = UsuarioUpdateOnlyRepositoryBuilder.Instancia().RecuperarPorId(usuario).Construir();
        EncriptadorDeSenha encriptador = EncriptadorDeSenhaBuilder.Instancia();
        IUnityOfWork unityOfWork = UnityOfWorkBuilder.Instancia().Construir();

        return new AlterarSenhaService(usuarioLogado, repository, encriptador, unityOfWork);
    }
}
