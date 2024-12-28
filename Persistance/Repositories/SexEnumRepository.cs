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

    public void Add( SexEnum sexEnum ) =>
            _context.Set<SexEnum>().Add( sexEnum );
    
    public void Remove( SexEnum sexEnum ) =>
        _context.Set<SexEnum>().Remove( sexEnum );

    public async Task<SexEnum?> GetById(
        int id,
        CancellationToken cancellationToken = default ) =>
            await _context.Set<SexEnum>()
                .FirstOrDefaultAsync(
                    x => x.Id == id,
                    cancellationToken );
}
