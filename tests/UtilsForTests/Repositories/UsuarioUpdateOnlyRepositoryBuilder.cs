using HairManager.Domain.Repositories.Usuario;
using Moq;

namespace UtilsForTests.Repositories;
public class UsuarioUpdateOnlyRepositoryBuilder
{
    private static UsuarioUpdateOnlyRepositoryBuilder _instance;
    private readonly Mock<IUsuarioUpdateOnlyRepository> _repository;

    private UsuarioUpdateOnlyRepositoryBuilder()
    {
        _repository ??= new Mock<IUsuarioUpdateOnlyRepository>();
    }

    public static UsuarioUpdateOnlyRepositoryBuilder Instancia()
    {
        _instance = new UsuarioUpdateOnlyRepositoryBuilder();
        return _instance;
    }

    public UsuarioUpdateOnlyRepositoryBuilder RecuperarPorId(HairManager.Domain.Entities.Usuario usuario)
    {
        _repository.Setup(c => c.RecuperarPorId(usuario.Id)).ReturnsAsync(usuario);

        return this;
    }

    public IUsuarioUpdateOnlyRepository Construir()
    {
        return _repository.Object;
    }
}
