﻿using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.EntityConfigurations;

public class SexEnumConfiguration : IEntityTypeConfiguration<SexEnum>
{
    public void Configure( EntityTypeBuilder<SexEnum> builder )
    {
        builder.ToTable( nameof( SexEnum ) );

        builder.HasKey( x => x.Id );

        builder.Property( x => x.SexName )
            .HasColumnName( "SexName" )
            .HasMaxLength( 8 )
            .IsRequired( true );

        builder.Property( x => x.Description )
            .HasColumnName( "Description" )
            .IsRequired( false );
        
        builder.HasData( 
            new SexEnum() { Id = 1, SexName = "Woman", Description = "sex enum woman" },
            new SexEnum() { Id = 2, SexName = "Man", Description = "sex enum man" } 
            );

    }
}
