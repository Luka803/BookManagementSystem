using BookManagementSystem.Application.Contracts.Persistence.Base;
using BookManagementSystem.Domain;
using BookManagementSystem.Domain.Base;

namespace BookManagementSystem.Application.Contracts.Persistence;

public interface IOrderRepository : IGenericRepository<Order>
{
    public Task<Order> GetOrderWithItems(Guid id);
    Task<IReadOnlyList<Order>> GetUserOrders(Guid userId);
}



