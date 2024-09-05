using Domain.Entities.Base;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.EntityConfigurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure( EntityTypeBuilder<User> builder )
    {
        builder.ToTable( typeof( User ).Name );
        builder.HasKey( x => x.Id );

        builder.OwnsOne( x => x.Name )
            .Property( x => x.FirstName )
            .HasMaxLength( Name.MaxNameLength )
            .IsRequired();

        builder.OwnsOne(x=>x.Name)
            .Property(x=>x.LastName )
            .HasMaxLength( Name.MaxNameLength )
            .IsRequired();

        builder.Property( x => x.Sex );

        builder.Property( x => x.EmailAddress );

        builder.Property( x => x.Phone );
    }
}
