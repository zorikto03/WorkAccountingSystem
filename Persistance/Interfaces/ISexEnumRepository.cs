using Domain.Entities.Base;

namespace Persistance.Interfaces;

public interface ISexEnumRepository
{
    Task<SexEnum?> GetById( int id, CancellationToken cancellationToken = default );
}
