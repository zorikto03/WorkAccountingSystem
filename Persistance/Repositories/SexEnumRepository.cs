using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Persistance.Interfaces;

namespace Persistance.Repositories;

public class SexEnumRepository : ISexEnumRepository
{
    ApplicationDbContext _context;

    public SexEnumRepository( ApplicationDbContext context )
    {
        _context = context;
    }
    public async Task<SexEnum?> GetById( int id, CancellationToken cancellationToken = default ) =>
        await _context.Set<SexEnum>()
            .AsNoTracking()
            .FirstOrDefaultAsync(
                x => x.Id == id,
                cancellationToken );
}
