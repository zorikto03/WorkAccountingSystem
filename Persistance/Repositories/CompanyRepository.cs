using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Interfaces;

namespace Persistance.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly ApplicationDbContext _context;

    public CompanyRepository(ApplicationDbContext applicationDbContext) => 
        _context = applicationDbContext;

    public async Task<List<Company>> GetAllAsync( 
        CancellationToken cancellationToken = default ) =>
            await _context.Set<Company>()
                .AsNoTracking()
                .ToListAsync( cancellationToken );

    public async Task<Company?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default ) =>
            await _context.Set<Company>()
                .AsNoTracking()
                .FirstOrDefaultAsync( x => x.Id == id, cancellationToken );
}
