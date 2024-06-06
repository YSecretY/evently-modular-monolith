using Evently.Shared.Application.Abstractions.Time;
using Evently.Shared.Infrastructure.AbstractionsImplementation.Time;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;

namespace Evently.Shared.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services, string dbConnectionString)
    {
        var npgsqlDatasource = new NpgsqlDataSourceBuilder(dbConnectionString).Build();
        services.TryAddSingleton(npgsqlDatasource);

        services.TryAddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }
}