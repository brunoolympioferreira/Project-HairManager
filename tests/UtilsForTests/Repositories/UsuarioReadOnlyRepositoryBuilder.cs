using HairManager.Domain.Repositories;
using Moq;

namespace UtilsForTests.Repositories;
public class UsuarioReadOnlyRepositoryBuilder
{
    private static UsuarioReadOnlyRepositoryBuilder _instance;
    private readonly Mock<IUsuarioReadOnlyRepository> _repository;

    private UsuarioReadOnlyRepositoryBuilder()
    {
        if (_repository == null)
        {
            _repository = new Mock<IUsuarioReadOnlyRepository>();
        }
    }

    public static UsuarioReadOnlyRepositoryBuilder Instancia()
    {
        _instance = new UsuarioReadOnlyRepositoryBuilder();
        return _instance;
    }

    public UsuarioReadOnlyRepositoryBuilder ExisteUsuarioComEmail(string email)
    {
        if (!string.IsNullOrEmpty(email))
            _repository.Setup(i => i.ExisteUsuarioComEmail(email)).ReturnsAsync(true);

        return this;
    }

    public IUsuarioReadOnlyRepository Construir()
    {
        return _repository.Object;
    }
}
