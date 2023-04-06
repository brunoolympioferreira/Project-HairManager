using HairManager.Application.Services.Endereco;
using UtilsForTests.Mapper;

namespace Business.Test.Endereco;
public class EnderecoServiceTest
{
    private static EnderecoService _instance;
    private static EnderecoService CriarService(HairManager.Domain.Entities.Endereco endereco)
    {
        var mapper = MapperBuilder.Instancia();

        return new EnderecoService(mapper);
    }

    public static EnderecoService Instancia()
    {
        var mapper = MapperBuilder.Instancia();

        _instance = new EnderecoService(mapper);
        return _instance;
    }
}
