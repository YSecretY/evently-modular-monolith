using System.Reflection;
using FluentValidation;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace Evently.Shared.Application;

public static class ApplicationConfiguration
{
    public static IServiceCollection AddSharedApplication(this IServiceCollection services, Assembly[] moduleAssemblies)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(moduleAssemblies));

        services.AddValidatorsFromAssemblies(moduleAssemblies, includeInternalTypes: true);

        services.AddMapster();

        return services;
    }
}