using Domain.Entities;
using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Persistance;

public interface IApplicationDbContext
{
    public DbSet<User> Users{ get; set; }
    public DbSet<Company> Companies { get; set; }
}
