using HairManager.Comunication.Requests;
using HairManager.Exceptions.ExceptionsBase;
using Newtonsoft.Json;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace WebApi.Test.V1;
public class ControllerBase : IClassFixture<HairManagerApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ControllerBase(HairManagerApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
        ResourceMensagensDeErro.Culture = CultureInfo.CurrentCulture;
    }

    protected async Task<HttpResponseMessage> PostRequest(string metodo, object body)
    {
        string jsonString = JsonConvert.SerializeObject(body);

        return await _client.PostAsync(metodo, new StringContent(jsonString, Encoding.UTF8, "application/json"));
    }

    protected async Task<string> Login(string email, string senha)
    {
        RequestLoginDTO request = new()
        {
            Email = email,
            Senha = senha
        };

        HttpResponseMessage response = await PostRequest("api/login", request);

        await using Stream responseBody = await response.Content.ReadAsStreamAsync();

        JsonDocument responseData = await JsonDocument.ParseAsync(responseBody);

        return responseData.RootElement.GetProperty("token").GetString();
    }

    protected async Task<HttpResponseMessage> GetRequest(string metodo, string token = "")
    {
        AutorizarRequisicao(token);

        return await _client.GetAsync(metodo);
    }
    
    protected async Task<HttpResponseMessage> PutRequest(string metodo, object body, string token = "")
    {
        AutorizarRequisicao(token);

        string jsonString = JsonConvert.SerializeObject(body);

        return await _client.PutAsync(metodo, new StringContent(jsonString, Encoding.UTF8, "application/json"));
    }

    private void AutorizarRequisicao(string token)
    {
        if (!string.IsNullOrWhiteSpace(token))
        {
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        }
    }


}
