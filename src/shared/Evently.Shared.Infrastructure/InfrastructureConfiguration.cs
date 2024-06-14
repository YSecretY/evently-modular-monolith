using Evently.Shared.Application.Abstractions.Caching;
using Evently.Shared.Application.Abstractions.Time;
using Evently.Shared.Infrastructure.Implementation.Caching;
using Evently.Shared.Infrastructure.Implementation.Time;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;
using StackExchange.Redis;

namespace Evently.Shared.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services, string dbConnectionString, string redisConnectionString)
    {
        var npgsqlDatasource = new NpgsqlDataSourceBuilder(dbConnectionString).Build();
        services.TryAddSingleton(npgsqlDatasource);

        services.TryAddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddRedis(redisConnectionString);

        return services;
    }

    private static IServiceCollection AddRedis(this IServiceCollection services, string redisConnectionString)
    {
        try
        {
            IConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(redisConnectionString);
            services.TryAddSingleton(connectionMultiplexer);

            services.AddStackExchangeRedisCache(options => options.ConnectionMultiplexerFactory = () => Task.FromResult(connectionMultiplexer));
        }
        catch
        {
            services.AddDistributedMemoryCache();
        }

        services.TryAddSingleton<IChacheService, CacheService>();

        return services;
    }
}