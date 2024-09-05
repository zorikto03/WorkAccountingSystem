using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Interfaces;

namespace Persistance.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly IApplicationDbContext _context;

    public CompanyRepository(IApplicationDbContext applicationDbContext) => 
        _context = applicationDbContext;

    public async Task<List<Company>> GetAllAsync( 
        CancellationToken cancellationToken = default ) =>
            await _context.Companies
                .AsNoTracking()
                .ToListAsync( cancellationToken );

    public async Task<Company?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default ) =>
            await _context.Companies
                .AsNoTracking()
                .FirstOrDefaultAsync( x => x.Id == id, cancellationToken );
}
