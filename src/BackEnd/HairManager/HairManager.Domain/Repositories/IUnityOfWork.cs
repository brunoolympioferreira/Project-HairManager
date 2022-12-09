namespace HairManager.Domain.Repositories;

public interface IUnityOfWork
{
    Task Commit();
}
