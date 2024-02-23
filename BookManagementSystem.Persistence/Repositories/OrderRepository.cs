using BookManagementSystem.Application.Contracts.Persistence;
using BookManagementSystem.Domain;
using BookManagementSystem.Persistence.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace BookManagementSystem.Persistence.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(BookManagementSystemDbContext dbContext) : base(dbContext)
    {
    }
    public async Task<Order> GetOrderWithItems(Guid id)
    {
        return await _dbContext.Orders
            .Include(x => x.OrderItems)
            .SingleOrDefaultAsync(x => x.ID == id);
    }

    public async Task<IReadOnlyList<Order>> GetUserOrders(Guid userId)
    {
        var orders = await _dbContext.Orders
            .Where(x => x.UserID == userId)
            .ToListAsync();
        return orders;
    }
}
