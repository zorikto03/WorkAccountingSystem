using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.EntityConfigurations;

internal class AlmanacConfiguration : IEntityTypeConfiguration<Almanac>
{
    public void Configure( EntityTypeBuilder<Almanac> builder )
    {
        throw new NotImplementedException();
    }
}
