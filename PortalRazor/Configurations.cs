using Persistance.DependencyInjection;

namespace PortalRazor;

/// <summary>
/// App configuration`s class
/// </summary>
public static class Configurations
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration )
    {
        services.AddPersistance( configuration );
    }
}
