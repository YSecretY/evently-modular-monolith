using System.Reflection;
using Evently.Modules.Event.Application.Events.Create;
using Evently.Modules.Event.Application.Events.Get;
using Evently.Modules.Event.Domain.Events;
using Evently.Modules.Event.Infrastructure.Database;
using Evently.Modules.Event.Presentation.Events.Controllers;
using FluentValidation;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evently.Modules.Event.Infrastructure;

public static class EventsModule
{
    private static void MapControllers(this IServiceCollection services) =>
        services.AddControllers()
            .AddApplicationPart(typeof(EventsController).Assembly);

    public static IServiceCollection AddEventsModule(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddInfrastructure(configuration)
            .AddApplication();

        MapControllers(services);

        return services;
    }

    private static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddPersistence(configuration)
            .AddApplication();

        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IEventsDbContext, EventsDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("EventsDbConnection")));

        return services;
    }

    private static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), includeInternalTypes: true);

        services.AddMapster();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        services.AddTransient<IRequestHandler<CreateEventCommand, Guid>, CreateEventCommandHandler>();
        services.AddTransient<IRequestHandler<GetEventQuery, EventEntity>, GetEventQueryHandler>();

        return services;
    }
}