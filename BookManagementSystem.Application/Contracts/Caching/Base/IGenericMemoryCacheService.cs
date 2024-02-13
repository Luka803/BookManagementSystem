using BookManagementSystem.Domain.Base;

namespace BookManagementSystem.Application.Contracts.Caching.Base;

public interface IGenericMemoryCacheService<T> where T : BaseEntity
{
    Task<IReadOnlyList<T>> GetOrSet(string cacheKey, Func<IReadOnlyList<T>> dataRetrievalFunction, TimeSpan cacheDuration);
    Task<T?> GetSingle(string cacheKey);
    Task SetSingle(string cacheKey, T data, TimeSpan cacheDuration);
    Task RemoveFromCache(string cacheKey);
}
