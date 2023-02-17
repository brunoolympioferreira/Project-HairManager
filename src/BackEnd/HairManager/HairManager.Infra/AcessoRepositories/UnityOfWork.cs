using HairManager.Domain.Repositories;

namespace HairManager.Infra.AcessoRepositories;

public sealed class UnityOfWork : IDisposable, IUnityOfWork
{
    private readonly HairManagerContext _context;
    private bool _disposed;

    public UnityOfWork(HairManagerContext context)
    {
        _context = context;
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
    }

    private void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            _context.Dispose();
        }

        _disposed = true;
    }
}
