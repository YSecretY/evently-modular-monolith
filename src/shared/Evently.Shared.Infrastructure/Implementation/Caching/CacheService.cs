using System.Buffers;
using System.Text.Json;
using Evently.Shared.Application.Abstractions.Caching;
using Microsoft.Extensions.Caching.Distributed;

namespace Evently.Shared.Infrastructure.Implementation.Caching;

internal sealed class CacheService(
    IDistributedCache cache
) : IChacheService
{
    public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
    {
        var bytes = await cache.GetAsync(key, cancellationToken);

        return bytes is null ? default(T) : Deserialize<T>(bytes);
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan? expiration = null, CancellationToken cancellationToken = default)
    {
        var bytes = await Serialize(value);

        await cache.SetAsync(key, bytes, CacheOptions.Create(expiration), cancellationToken);
    }

    public async Task RemoveAsync(string key, CancellationToken cancellationToken = default) =>
        await cache.RemoveAsync(key, cancellationToken);

    private static T Deserialize<T>(byte[] bytes) =>
        JsonSerializer.Deserialize<T>(bytes) ?? throw new NullReferenceException("Cannot deserialize null.");

    private static async Task<byte[]> Serialize<T>(T value)
    {
        var buffer = new ArrayBufferWriter<byte>();
        await using var writer = new Utf8JsonWriter(buffer);

        JsonSerializer.Serialize(writer, value);

        return buffer.WrittenSpan.ToArray();
    }
}