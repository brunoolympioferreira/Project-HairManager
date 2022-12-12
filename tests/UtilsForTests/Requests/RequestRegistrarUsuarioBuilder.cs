using Bogus;
using HairManager.Comunication.Requests;

namespace UtilsForTests.Requests;
public class RequestRegistrarUsuarioBuilder
{
    public static RequestRegistrarUsuarioDTO Construir(int tamanhoSenha = 10)
    {
        return new Faker<RequestRegistrarUsuarioDTO>()
            .RuleFor(c => c.Nome, f => f.Person.FullName)
            .RuleFor(c => c.Email, f => f.Internet.Email())
            .RuleFor(c => c.Senha, f => f.Internet.Password(tamanhoSenha))
            .RuleFor(c => c.Status, f => f.PickRandomParam(new bool[] { true, true, false }));
    }
}
