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
            (sp, option) =>
            {
                option.UseSqlite( configuration.GetConnectionString( "Sqlite" ) );
            } );

        // add repositories
        services.AddScoped<IUserRepository, UserRepository>();
        //services.AddScoped<ICompanyRepository, CompanyRepository>();
        return services;
    }
}
