using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure( EntityTypeBuilder<User> builder )
    {
        builder.ToTable( nameof( User ) );

        builder.HasKey( x => x.Id );

        builder.OwnsOne( n => n.Name, p =>
        {
            p.Property( f => f.FirstName )
            .HasColumnName( "FirstName" )
            .HasColumnType("nvarchar(32)")
            //.HasMaxLength( Name.MaxNameLength )
            .IsRequired( true );

            p.Property( f => f.LastName )
            .HasColumnName( "LastName" )
            .HasColumnType( "nvarchar(32)" )
            //.HasMaxLength( Name.MaxNameLength )
            .IsRequired( true );
        } );

        builder.Property( x => x.Sex )
            .HasColumnName( "Sex" )
            .IsRequired( true );

        builder.OwnsOne( x => x.LoginPassword, p =>
        {
            p.Property( l => l.Login )
            .HasColumnName( "Login" )
            .HasColumnType( "nvarchar(32)" )
            //.HasMaxLength( 32 )
            .IsRequired( true );

            p.Property( y => y.Password )
            .HasColumnName( "Password" )
            .HasColumnType( "nvarchar(32)" )
            //.HasMaxLength( 32 )
            .IsRequired( true );
        } );
    }
}
