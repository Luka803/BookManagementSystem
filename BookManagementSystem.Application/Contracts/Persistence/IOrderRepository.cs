using BookManagementSystem.Application.Contracts.Persistence.Base;
using BookManagementSystem.Domain;

namespace BookManagementSystem.Application.Contracts.Persistence;

public interface IOrderRepository : IGenericRepository<Order>
{
    public Task<Order> GetOrderWithItems(Guid id);
}



