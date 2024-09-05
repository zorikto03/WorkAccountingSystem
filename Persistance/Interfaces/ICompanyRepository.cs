using Domain.Entities;

namespace Persistance.Interfaces;

public interface ICompanyRepository
{
    Task<Company?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<Company>> GetAllAsync(CancellationToken cancellationToken = default);
}
