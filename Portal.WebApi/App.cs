using Application.Configurations;
using Persistance.DependencyInjection;
using Portal.WebApi.Common;
using System.Reflection;

namespace Portal.WebApi;

public static class App
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddAutoMapper( config =>
        {
            config.AllowNullCollections = true;
            config.AddProfile( new AssemblyMappingProfile( Assembly.GetExecutingAssembly() ) );
        } );

        services.AddPersistance( configuration );
        services.AddApplication();

        return services;
    }
}
