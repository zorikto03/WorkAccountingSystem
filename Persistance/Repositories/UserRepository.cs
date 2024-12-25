using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Persistance.Interfaces;

namespace Persistance.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository( ApplicationDbContext applicationDbContext ) =>
        _context = applicationDbContext;

    public async Task<List<User>> GetAllAsync(
        CancellationToken cancellationToken = default ) =>
            await _context.Set<User>()
                .AsNoTracking()
                .ToListAsync( cancellationToken );

    public async Task<User?> GetByIdAsync( 
        Guid id, 
        CancellationToken cancellationToken = default ) =>
            await _context.Set<User>()
                .AsNoTracking()
                .FirstOrDefaultAsync( x => x.Id == id, cancellationToken );

    public async Task Add( User user ) =>
        await _context.Set<User>().AddAsync( user );

    public void Remove( User user ) =>
        _context.Set<User>().Remove( user );
}
