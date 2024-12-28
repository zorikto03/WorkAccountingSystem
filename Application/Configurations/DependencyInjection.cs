using Application.Common.Behaviours;
using MediatR.NotificationPublishers;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Configurations;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // add services applications layer
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly( Assembly.GetExecutingAssembly() );

            cfg.AddOpenBehavior( typeof( LoggingPipelineBehaviour<,> ) );
            cfg.AddOpenBehavior( typeof( UnitOfWorkPipelineBehaviour<,> ) );

            cfg.NotificationPublisher = new TaskWhenAllPublisher();
            cfg.NotificationPublisherType = typeof( TaskWhenAllPublisher );
        } );
        
        return services;
    }
}
