using BookManagementSystem.Application.Contracts.Caching.Base;
using BookManagementSystem.Domain.Base;
using Microsoft.Extensions.Caching.Memory;

namespace BookManagementSystem.Infrastructure.Caching;

public class MemoryCacheService<T> : IGenericMemoryCacheService<T> where T : BaseEntity
{
    private readonly IMemoryCache _cache;

    public MemoryCacheService(IMemoryCache cache)
    {
        _cache = cache;
    }
    public async Task<IReadOnlyList<T>> GetOrSet(string cacheKey, Func<IReadOnlyList<T>> dataRetrievalFunction, TimeSpan cacheDuration)
    {
        var cachedData = _cache.Get(cacheKey) as List<T>;

        if (cachedData == null)
        {
            cachedData = (List<T>?)dataRetrievalFunction.Invoke();

            if (cachedData != null)
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = cacheDuration,
                };

                _cache.Set(cacheKey, cachedData, cacheEntryOptions);
            }
        }
        await Task.CompletedTask;
        return cachedData;
    }

    public async Task<T?> GetSingle(string cacheKey)
    {
        await Task.CompletedTask;
        var cached = _cache.Get(cacheKey);
        return cached as T;
    }

    public async Task RemoveFromCache(string cacheKey)
    {
        if (_cache.TryGetValue(cacheKey, out _))
        {
            _cache.Remove(cacheKey);
        }

        await Task.CompletedTask;
    }

    public async Task SetSingle(string cacheKey, T data, TimeSpan cacheDuration)
    {
        await Task.CompletedTask;
        _cache.Set(cacheKey, data, new MemoryCacheEntryOptions() { AbsoluteExpirationRelativeToNow = cacheDuration });
    }
}
