using BookManagementSystem.Application.Contracts.Caching.Base;
using BookManagementSystem.Domain;

namespace BookManagementSystem.Application.Contracts.Caching;

public interface IOrderItemMemoryCacheService : IGenericMemoryCacheService<OrderItem>
{
}


