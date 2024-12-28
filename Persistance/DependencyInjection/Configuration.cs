using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Interfaces;
using Persistance.Repositories;
using System.Runtime.CompilerServices;

namespace Persistance.DependencyInjection;

public static class Configuration
{
    public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextFactory<ApplicationDbContext>(
            ( sp, options ) => options
                .UseSqlite( configuration.GetConnectionString( "Sqlite" ) ?? string.Empty ));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // add repositories
        services.AddScoped<ISexEnumRepository, SexEnumRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
