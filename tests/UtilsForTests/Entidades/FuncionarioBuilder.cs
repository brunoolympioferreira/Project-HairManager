using Bogus;
using Bogus.Extensions.Brazil;
using HairManager.Domain.Entities;
using HairManager.Domain.Enums;
using System;

namespace UtilsForTests.Entidades;
public class FuncionarioBuilder
{
    public static Funcionario Construir()
    {
        return new Faker<Funcionario>()
            .RuleFor(c => c.Id, _ => 1)
            .RuleFor(c => c.Nome, f => f.Person.FullName)
            .RuleFor(c => c.Telefone, f => f.Phone.PhoneNumber("############"))
            .RuleFor(c => c.DataNascimento, f => f.Date.Past(60, DateTime.Now.AddYears(-16)))
            .RuleFor(c => c.Nacionalidade, "Brasileiro")
            .RuleFor(c => c.CTPSNumero, "2525252525")
            .RuleFor(c => c.CTPSSerie, f => "3654")
            .RuleFor(c => c.CPF, f => f.Person.Cpf(false))
            .RuleFor(c => c.RG, f => "30998355")
            .RuleFor(c => c.PIS, f => "1023589748")
            .RuleFor(c => c.Reservista, "25871456987")
            .RuleFor(c => c.Cargo, f => "Cabelereiro")
            .RuleFor(c => c.Salario, 1500.55m)
            .RuleFor(c => c.EstadoCivil, f => f.Random.Enum<EstadoCivilEnum>())
            .RuleFor(c => c.DataAdmissao, f => f.Date.Recent())
            .RuleFor(c => c.StatusFuncionario, f => f.Random.Enum<StatusFuncionarioEnum>())
            .RuleFor(c => c.EnderecoId, _ => 1);
    }
}
