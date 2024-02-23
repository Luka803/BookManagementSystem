using BookManagementSystem.Application.Contracts.Persistence.Base;
using BookManagementSystem.Domain;

namespace BookManagementSystem.Application.Contracts.Persistence;

public interface IOrderItemRepository : IGenericRepository<OrderItem>
{
    public Task<List<OrderItem>> GetBookOrders(Guid id);
}



