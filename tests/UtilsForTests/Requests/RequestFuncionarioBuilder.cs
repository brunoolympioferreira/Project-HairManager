using Bogus;
using Bogus.Extensions.Brazil;
using HairManager.Comunication.DTO;
using HairManager.Comunication.Enums;
using HairManager.Comunication.Requests;
using System;

namespace UtilsForTests.Requests;
public class RequestFuncionarioBuilder
{
    public static RequestFuncionarioDTO Construir()
    {
        return new Faker<RequestFuncionarioDTO>()
            .RuleFor(c => c.Nome, f => f.Person.FullName)
            .RuleFor(c => c.Telefone, f => f.Phone.PhoneNumber("############"))
            .RuleFor(c => c.DataNascimento, f => f.Date.Past(60, DateTime.Now.AddYears(-16)))
            .RuleFor(c => c.Nacionalidade, "Brasileiro")
            .RuleFor(c => c.Endereco, Endereco())
            .RuleFor(c => c.CTPSNumero, "2525252525")
            .RuleFor(c => c.CTPSSerie, f => "3654")
            .RuleFor(c => c.CPF, f => f.Person.Cpf(false))
            .RuleFor(c => c.RG, f => "30998355")
            .RuleFor(c => c.PIS, f => "1023589748")
            .RuleFor(c => c.Reservista,"25871456987")
            .RuleFor(c => c.Cargo, f => "Cabelereiro")
            .RuleFor(c => c.Salario, 1500.55m)
            .RuleFor(c => c.EstadoCivil, f => f.Random.Enum<EstadoCivilEnum>())
            .RuleFor(c => c.DataAdmissao, f => f.Date.Recent())
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
