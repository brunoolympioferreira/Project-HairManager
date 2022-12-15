using FluentAssertions;
using HairManager.Exceptions.ExceptionsBase;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using UtilsForTests.Requests;
using Xunit;

namespace WebApi.Test.V1.Usuario.Registrar;
public class RegistrarUsuarioTest : ControllerBase
{
    private const string METODO = "api/usuario";
    public RegistrarUsuarioTest(HairManagerApplicationFactory<Program> factory) : base(factory) { }

    [Fact]
    public async Task Validar_Sucesso()
    {
        var request = RequestRegistrarUsuarioBuilder.Construir();
        request.ConfirmeSenha = request.Senha;

        var response = await PostRequest(METODO, request);

        response.StatusCode.Should().Be(HttpStatusCode.Created);

        await using var responseBody = await response.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(responseBody);

        responseData.RootElement.GetProperty("token").GetString().Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task Validar_Erro_Nome_Vazio()
    {
        var request = RequestRegistrarUsuarioBuilder.Construir();
        request.ConfirmeSenha = request.Senha;
        request.Nome = string.Empty;

        var response = await PostRequest(METODO, request);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        await using var responseBody = await response.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(responseBody);

        var erros = responseData.RootElement.GetProperty("mensagens").EnumerateArray();
        erros.Should().ContainSingle().And.Contain(c => c.GetString().Equals(ResourceMensagensDeErro.NOME_USUARIO_EMBRANCO));
    }
}
