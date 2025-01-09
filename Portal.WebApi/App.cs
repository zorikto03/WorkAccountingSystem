using Application.Configurations;
using Persistance;
using Persistance.DependencyInjection;
using Portal.WebApi.Common;
using System.Reflection;

namespace Portal.WebApi;

public static class App
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        
        services.AddAuthentication("Bearer")
            .AddJwtBearer();
        services.AddAuthorization();

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

    public static void ConfigureApplication(WebApplication app)
    {
        // initial db
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.Database.EnsureCreated();

        // Configure the HTTP request pipeline.
        if ( app.Environment.IsDevelopment() )
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.UseAuthentication();
        app.UseAuthorization();
    }
}
