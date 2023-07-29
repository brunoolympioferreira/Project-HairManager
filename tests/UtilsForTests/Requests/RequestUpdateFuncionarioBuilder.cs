using Bogus;
using HairManager.Comunication.DTO;
using HairManager.Comunication.Enums;
using HairManager.Comunication.Requests;

namespace UtilsForTests.Requests;
public class RequestUpdateFuncionarioBuilder
{
    public static RequestUpdateFuncionarioDTO Construir()
    {
        return new Faker<RequestUpdateFuncionarioDTO>()
            .RuleFor(c => c.Telefone, f => f.Phone.PhoneNumber("############"))
            .RuleFor(c => c.Endereco, Endereco())
            .RuleFor(c => c.Cargo, f => "Cabelereiro Senior")
            .RuleFor(c => c.Salario, 5500.55m)
            .RuleFor(c => c.EstadoCivil, f => f.Random.Enum<EstadoCivilEnum>())
            .RuleFor(c => c.DataDemissao, f => f.Date.Recent())
            .RuleFor(c => c.StatusFuncionario, f => f.Random.Enum<StatusFuncionarioEnum>());
    }

    private static EnderecoDTO Endereco()
    {
        return new Faker<EnderecoDTO>()
            .RuleFor(e => e.Rua, f => f.Address.StreetName())
            .RuleFor(e => e.Numero, "1000")
            .RuleFor(e => e.Numero, "1000")
            .RuleFor(e => e.Complemento, f => f.Lorem.Text())
            .RuleFor(e => e.Bairro, f => f.Address.County())
            .RuleFor(e => e.Cidade, f => f.Address.City())
            .RuleFor(e => e.Estado, f => f.Random.Enum<EstadosEnum>())
            .RuleFor(e => e.Pais, f => f.Address.Country());
    }
}
