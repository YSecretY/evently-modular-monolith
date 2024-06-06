using System.Reflection;
using Evently.Modules.Event.Application.Abstraction;
using Evently.Modules.Event.Application.Categories.Commands.Archive;
using Evently.Modules.Event.Application.Categories.Commands.Create;
using Evently.Modules.Event.Application.Categories.Commands.Update;
using Evently.Modules.Event.Application.Categories.Queries.Get;
using Evently.Modules.Event.Application.Categories.Queries.GetList;
using Evently.Modules.Event.Application.Events.Commands.Cancel;
using Evently.Modules.Event.Application.Events.Commands.Create;
using Evently.Modules.Event.Application.Events.Commands.Publish_;
using Evently.Modules.Event.Application.Events.Commands.Reschedule;
using Evently.Modules.Event.Application.Events.Queries.Get;
using Evently.Modules.Event.Application.Events.Queries.GetList;
using Evently.Modules.Event.Application.Events.Queries.Search;
using Evently.Modules.Event.Application.TicketTypes.Commands.Create;
using Evently.Modules.Event.Application.TicketTypes.Commands.UpdatePrice;
using Evently.Modules.Event.Application.TicketTypes.Queries.Get;
using Evently.Modules.Event.Application.TicketTypes.Queries.GetList;
using Evently.Modules.Event.Domain.Categories;
using Evently.Modules.Event.Domain.Events;
using Evently.Modules.Event.Domain.TicketTypes;
using Evently.Modules.Event.Infrastructure.Database;
using Evently.Modules.Event.Infrastructure.Services.Time;
using Evently.Modules.Event.Presentation.Events.Controllers;
using FluentValidation;
using Mapster;
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

        services.AddTransient<IDateTimeProvider, DateTimeProvider>();

        services.AddTransient<IRequestHandler<CreateEventCommand, Guid>, CreateEventCommandHandler>();
        services.AddTransient<IRequestHandler<GetEventQuery, EventEntity>, GetEventQueryHandler>();
        services.AddTransient<IRequestHandler<GetEventsListQuery, GetEventsListQueryResponse>, GetEventsListQueryHandler>();
        services.AddTransient<IRequestHandler<CancelEventCommand>, CancelEventCommandHandler>();
        services.AddTransient<IRequestHandler<PublishEventCommand>, PublishEventCommandHandler>();
        services.AddTransient<IRequestHandler<RescheduleEventCommand>, RescheduleEventCommandHandler>();
        services.AddTransient<IRequestHandler<SearchEventsQuery, SearchEventsQueryResponse>, SearchEventsQueryHandler>();

        services.AddTransient<IRequestHandler<CreateTicketTypeCommand, Guid>, CreateTicketTypeCommandHandler>();
        services.AddTransient<IRequestHandler<GetTicketTypeQuery, TicketType>, GetTicketTypeQueryHandler>();
        services.AddTransient<IRequestHandler<GetTicketTypesListQuery, GetTicketTypesListQueryResponse>, GetTicketTypesListQueryHandler>();
        services.AddTransient<IRequestHandler<UpdateTicketTypePriceCommand>, UpdateTicketTypePriceCommandHandler>();

        services.AddTransient<IRequestHandler<CreateCategoryCommand, Guid>, CreateCategoryCommandHandler>();
        services.AddTransient<IRequestHandler<GetCategoryQuery, Category>, GetCategoryQueryHandler>();
        services.AddTransient<IRequestHandler<ArchiveCategoryCommand>, ArchiveCategoryCommandHandler>();
        services.AddTransient<IRequestHandler<GetCategoriesListQuery, GetCategoriesListQueryResponse>, GetCategoriesListQueryHandler>();
        services.AddTransient<IRequestHandler<UpdateCategoryCommand>, UpdateCategoryCommandHandler>();

        return services;
    }
}