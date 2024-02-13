using BookManagementSystem.Application.Contracts.Caching;
using BookManagementSystem.Application.Contracts.Logging;
using BookManagementSystem.Domain;
using Microsoft.Extensions.Caching.Memory;

namespace BookManagementSystem.Infrastructure.Caching;

public class AuthorCacheService : MemoryCacheService<Author>, IAuthorMemoryCacheService
{
    public AuthorCacheService(IMemoryCache cache) : base(cache)
    {
    }
}
