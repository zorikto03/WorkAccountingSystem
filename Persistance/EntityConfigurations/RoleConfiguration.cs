using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.EntityConfigurations;

internal class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure( EntityTypeBuilder<Role> builder )
    {
        throw new NotImplementedException();
    }
}
