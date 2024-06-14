using Evently.Modules.Events.Domain.Events;
using Evently.Modules.Events.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evently.Modules.Events.Infrastructure;

public static class EventsModule
{
    private static void MapControllers(this IServiceCollection services) =>
        services.AddControllers()
            .AddApplicationPart(Events.Presentation.AssemblyReference.Assembly);

    public static IServiceCollection AddEventsModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);

        MapControllers(services);

        return services;
    }

    private static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistence(configuration);

        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var dbConnectionString = configuration.GetConnectionString("Database") ?? throw new NullReferenceException("Database connection string is not found.");

        services.AddDbContext<IEventsDbContext, EventsDbContext>(options =>
            options.UseNpgsql(dbConnectionString, npgsqlOptions => npgsqlOptions.MigrationsHistoryTable(Schemas.Events)));

        return services;
    }
}