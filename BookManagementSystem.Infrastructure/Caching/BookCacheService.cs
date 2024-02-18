using BookManagementSystem.Application.Contracts.Caching;
using BookManagementSystem.Domain;
using Microsoft.Extensions.Caching.Memory;

namespace BookManagementSystem.Infrastructure.Caching;

public class BookCacheService : MemoryCacheService<Book>, IBookMemoryCacheService
{
    public BookCacheService(IMemoryCache cache) : base(cache)
    {
    }
}
