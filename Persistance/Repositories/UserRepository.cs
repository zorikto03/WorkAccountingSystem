using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Persistance.Interfaces;

namespace Persistance.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IApplicationDbContext _context;

    public UserRepository( IApplicationDbContext applicationDbContext ) =>
        _context = applicationDbContext;

    public async Task<List<User>> GetAllAsync(
        CancellationToken cancellationToken = default ) =>
            await _context.Users
                .AsNoTracking()
                .ToListAsync( cancellationToken );

    public async Task<User?> GetByIdAsync( 
        Guid id, 
        CancellationToken cancellationToken = default ) =>
            await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync( x => x.Id == id, cancellationToken );
}
