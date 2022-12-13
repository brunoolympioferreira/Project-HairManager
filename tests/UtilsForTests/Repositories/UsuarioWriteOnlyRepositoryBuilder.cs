using HairManager.Domain.Repositories;
using Moq;

namespace UtilsForTests.Repositories;
public class UsuarioWriteOnlyRepositoryBuilder
{
    private static UsuarioWriteOnlyRepositoryBuilder _instance;
    private readonly Mock<IUsuarioWriteOnlyRepository> _repository;

    private UsuarioWriteOnlyRepositoryBuilder()
    {
        if (_repository == null)
        {
            _repository = new Mock<IUsuarioWriteOnlyRepository>();
        }
    }

    public static UsuarioWriteOnlyRepositoryBuilder Instancia()
    {
        _instance = new UsuarioWriteOnlyRepositoryBuilder();
        return _instance;
    }

    public IUsuarioWriteOnlyRepository Construir()
    {
        return _repository.Object;
    }
}
