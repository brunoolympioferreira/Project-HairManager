using Bogus;
using HairManager.Comunication.Requests;

namespace UtilsForTests.Requests;
public class RequestAlterarSenhaUsuarioBuilder
{
    public static RequestAlterarSenhaDTO Construir(int tamanhoSenha = 10)
    {
        return new Faker<RequestAlterarSenhaDTO>()
            .RuleFor(c => c.SenhaAtual, f => f.Internet.Password(8))
            .RuleFor(c => c.NovaSenha, f => f.Internet.Password(tamanhoSenha));
    }
}
