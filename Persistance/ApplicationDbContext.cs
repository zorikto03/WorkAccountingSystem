using Domain.Entities;
using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Persistance.EntityConfigurations;

namespace Persistance;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        modelBuilder.ApplyConfiguration( new UserConfiguration() );
        //modelBuilder.ApplyConfiguration( new CompanyConfiguration() );
        base.OnModelCreating( modelBuilder );
    }
}
