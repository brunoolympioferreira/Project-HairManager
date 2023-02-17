using FluentAssertions;
using HairManager.Comunication.Requests;
using HairManager.Exceptions.ExceptionsBase;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using UtilsForTests.Requests;
using Xunit;

namespace WebApi.Test.V1.Usuario.AlterarSenha;
public class AlterarSenhaTeste : ControllerBase
{
    private const string METODO = "api/usuario/alterar-senha";

    private HairManager.Domain.Entities.Usuario _usuario;
    private string _senha;
    public AlterarSenhaTeste(HairManagerApplicationFactory<Program> factory) : base(factory)
    {
        _usuario = factory.RecuperarUsuario();
        _senha = factory.RecuperarSenha();
    }

    [Fact]
    public async Task Validar_Sucesso()
    {
        string token = await Login(_usuario.Email, _senha);

        RequestAlterarSenhaDTO request = RequestAlterarSenhaUsuarioBuilder.Construir();
        request.SenhaAtual = _senha;
        request.ConfirmeNovaSenha = request.NovaSenha;

        HttpResponseMessage response = await PutRequest(METODO, request, token);

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task Validar_Erro_SenhaEmBranco()
    {
        string token = await Login(_usuario.Email, _senha);

        RequestAlterarSenhaDTO request = RequestAlterarSenhaUsuarioBuilder.Construir();
        request.SenhaAtual = _senha;
        request.NovaSenha = string.Empty;
        request.ConfirmeNovaSenha = string.Empty;

        HttpResponseMessage response = await PutRequest(METODO, request, token);

        await using Stream respostaBody = await response.Content.ReadAsStreamAsync();

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        JsonDocument responseData = await JsonDocument.ParseAsync(respostaBody);

        JsonElement.ArrayEnumerator erros = responseData.RootElement.GetProperty("mensagens").EnumerateArray();
        erros.Should().ContainSingle().And.Contain(x => x.GetString().Equals(ResourceMensagensDeErro.SENHA_USUARIO_EMBRANCO));

    }
}
