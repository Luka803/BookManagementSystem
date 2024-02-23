using BookManagementSystem.Application.Contracts.Caching;
using BookManagementSystem.Domain;
using Microsoft.Extensions.Caching.Memory;

namespace BookManagementSystem.Infrastructure.Caching;

public class OrderItemCacheService : MemoryCacheService<OrderItem>, IOrderItemMemoryCacheService
{
    public OrderItemCacheService(IMemoryCache cache) : base(cache)
    {
    }
}
