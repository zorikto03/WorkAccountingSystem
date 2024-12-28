using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Persistance.EntityConfigurations;
using System.Reflection.Metadata;

namespace Persistance;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options ) 
        : base( options )
    {
    }

    protected override void OnModelCreating( ModelBuilder builder )
    {
        //builder.ApplyConfigurationsFromAssembly( typeof( AssemblyReference ).Assembly );
        builder.ApplyConfiguration( new SexEnumConfiguration() );
        builder.ApplyConfiguration( new UserConfiguration() );

        base.OnModelCreating( builder );
    }
}
