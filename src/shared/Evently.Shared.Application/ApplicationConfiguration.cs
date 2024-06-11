using System.Reflection;
using Evently.Shared.Application.Behaviours.Logging;
using FluentValidation;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace Evently.Shared.Application;

public static class ApplicationConfiguration
{
    public static IServiceCollection AddSharedApplication(this IServiceCollection services, Assembly[] moduleAssemblies)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(moduleAssemblies);

            cfg.AddOpenBehavior(typeof(RequestLoggingPipelineBehaviour<,>));
        });

        services.AddValidatorsFromAssemblies(moduleAssemblies, includeInternalTypes: true);

        services.AddMapster();

        return services;
    }
}