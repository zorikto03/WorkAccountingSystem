﻿using Persistance.Interfaces;

namespace Persistance;

internal class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork( ApplicationDbContext context ) => 
        _context = context;

    public async Task SaveChangesAsync( CancellationToken cancellationToken = default ) =>
        await _context.SaveChangesAsync( cancellationToken );

    public void Dispose()
    {
        _context.Dispose();
    }
}
