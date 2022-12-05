namespace HairManager.Infra.AcessoRepositories;

public interface IUnityOfWork
{
    Task Commit();
}
