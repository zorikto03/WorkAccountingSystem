using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.EntityConfigurations;

internal class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure( EntityTypeBuilder<Company> builder )
    {
        builder.ToTable( typeof( Company ).Name );
        
        builder.HasKey( x => x.Id );

        builder.Property( x => x.Id );

        builder
            .Property( x => x.CompanyName )
            .HasConversion(
                x => x.Value,
                x => CompanyName.Create( x ).Value )
            .HasMaxLength( CompanyName.MaxCompanyNameLength )
            .IsRequired( true );

        builder
            .Property( x => x.Created )
            .IsRequired( true );

        builder
            .Property( x => x.Updated )
            .IsRequired( false );

        builder
            .HasMany( x => x.Users )
            .WithOne( x => x.Company )
            .HasForeignKey( x => x.CompanyId )
            .IsRequired( false )
            .OnDelete( DeleteBehavior.SetNull );
    }
}
