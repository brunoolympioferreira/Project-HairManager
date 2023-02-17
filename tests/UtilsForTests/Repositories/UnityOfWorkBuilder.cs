using HairManager.Domain.Repositories;
using Moq;

namespace UtilsForTests.Repositories;
public class UnityOfWorkBuilder
{
    private static UnityOfWorkBuilder _instance;
    private readonly Mock<IUnityOfWork> _repository;

    private UnityOfWorkBuilder()
    {
        if (_repository == null)
        {
            _repository = new Mock<IUnityOfWork>();
        }
    }

    public static UnityOfWorkBuilder Instancia()
    {
        _instance = new UnityOfWorkBuilder();
        return _instance;
    }

    public IUnityOfWork Construir()
    {
        return _repository.Object;
    }
}
