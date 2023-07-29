using Bogus;
using HairManager.Domain.Entities;
using HairManager.Domain.Enums;

namespace UtilsForTests.Entidades;
public class EnderecoBuilder
{
    public static Endereco Construir()
    {
        return new Faker<Endereco>()
            .RuleFor(c => c.Id, _ => 1)
            .RuleFor(e => e.Rua, r => r.Address.StreetName())
            .RuleFor(e => e.Numero, r => r.Address.BuildingNumber())
            .RuleFor(e => e.Complemento, r => "Complemento")
            .RuleFor(e => e.Bairro, r => r.Address.County())
            .RuleFor(e => e.Cidade, r => r.Address.City())
            .RuleFor(e => e.Estado, r => r.Random.Enum<EstadosEnum>())
            .RuleFor(e => e.Pais, r => "Brasil");
    }
}
