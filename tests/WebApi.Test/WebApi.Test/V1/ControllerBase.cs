using HairManager.Exceptions.ExceptionsBase;
using Newtonsoft.Json;
using System.Globalization;
using System.Net.Http;
using System.Text;
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
}
