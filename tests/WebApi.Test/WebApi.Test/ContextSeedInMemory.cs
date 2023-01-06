using HairManager.Domain.Entities;
using HairManager.Infra.AcessoRepositories;
using UtilsForTests.Entidades;

namespace WebApi.Test;
public class ContextSeedInMemory
{
    public static (Usuario usuario, string senha) Seed(HairManagerContext context)
    {
        (Usuario usuario, string senha) = UsuarioBuilder.Construir();

        context.Usuarios.Add(usuario);

        context.SaveChanges();

        return (usuario, senha);
    }
}
