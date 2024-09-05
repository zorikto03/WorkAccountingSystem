using Microsoft.Extensions.DependencyInjection;
using Persistance.Interfaces;
using Persistance.Repositories;
using System.Runtime.CompilerServices;

namespace Persistance.DependencyInjection;

public static class Configuration
{
    public static IServiceCollection AddPersistance(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>();

        // add repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        return services;
    }
}
