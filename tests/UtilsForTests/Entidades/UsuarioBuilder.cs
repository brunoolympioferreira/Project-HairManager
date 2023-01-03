using Bogus;
using HairManager.Domain.Entities;
using UtilsForTests.Criptografia;

namespace UtilsForTests.Entidades;
public class UsuarioBuilder
{
    public static (Usuario usuario, string senha) Construir()
    {
        string senha = string.Empty;

        var usuarioGerado = new Faker<Usuario>()
            .RuleFor(u => u.Id, _ => 1)
            .RuleFor(u => u.Nome, f => f.Person.FullName)
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.Senha, f =>
            {
                senha = f.Internet.Password();

                return EncriptadorDeSenhaBuilder.Instancia().CriptografarSenha(senha);
            })
            .RuleFor(u => u.ConfirmeSenha, _ => EncriptadorDeSenhaBuilder.Instancia().CriptografarConfirmeSenha(senha))
            .RuleFor(u => u.Status, f => f.Random.Bool());

        return (usuarioGerado, senha);
    }
}
