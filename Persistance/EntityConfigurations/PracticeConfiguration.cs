using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityConfigurations;

internal class PracticeConfiguration : IEntityTypeConfiguration<Practice>
{
    public void Configure( EntityTypeBuilder<Practice> builder )
    {
        throw new NotImplementedException();
    }
}
