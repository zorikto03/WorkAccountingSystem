namespace Persistance.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task SaveChangesAsync( CancellationToken cancellationToken = default );
}
