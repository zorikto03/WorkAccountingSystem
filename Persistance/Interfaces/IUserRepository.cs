using Domain.Entities.Base;

namespace Persistance.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default);

    Task Add(User user);
    void Remove(User user);
}
