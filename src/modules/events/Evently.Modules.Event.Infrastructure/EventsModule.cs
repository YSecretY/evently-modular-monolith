using Evently.Modules.Event.Domain.Events;
using Evently.Modules.Event.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evently.Modules.Event.Infrastructure;

public static class EventsModule
{
    private static void MapControllers(this IServiceCollection services) =>
        services.AddControllers()
            .AddApplicationPart(Presentation.AssemblyReference.Assembly);

    public static IServiceCollection AddEventsModule(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddInfrastructure(configuration);

        MapControllers(services);

        return services;
    }

    private static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddPersistence(configuration);

        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var dbConnectionString = configuration.GetConnectionString("DbConnection") ?? throw new NullReferenceException("Connection string is not found.");

        services.AddDbContext<IEventsDbContext, EventsDbContext>(options =>
            options.UseNpgsql(dbConnectionString, npgsqlOptions => npgsqlOptions.MigrationsHistoryTable(Schemas.Events)));

        return services;
    }
}