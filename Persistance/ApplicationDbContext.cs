using Domain.Entities;
using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Persistance.EntityConfigurations;

namespace Persistance;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
        //Database.EnsureDeleted();
        //Database.EnsureCreated();
    }

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        modelBuilder.ApplyConfiguration( new SexEnumConfiguration() );
        modelBuilder.ApplyConfiguration( new UserConfiguration() );
        
        base.OnModelCreating( modelBuilder );
    }

    protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
    {
        optionsBuilder.UseSqlite( "TestDb.db" );
        base.OnConfiguring( optionsBuilder );
    }
}
