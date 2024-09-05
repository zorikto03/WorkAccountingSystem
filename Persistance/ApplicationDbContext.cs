using Domain.Entities;
using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Persistance.EntityConfigurations;

namespace Persistance;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Company> Companies { get; set; }


    public ApplicationDbContext()
    {
        Database.EnsureCreated();
    }


    protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
    {
        optionsBuilder.UseSqlite( "Test.db" );
    }

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        modelBuilder.ApplyConfiguration( new UserConfiguration() );
        modelBuilder.ApplyConfiguration( new CompanyConfiguration() );
    }
}
