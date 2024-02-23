using BookManagementSystem.Application.Contracts.Persistence;
using BookManagementSystem.Domain;
using BookManagementSystem.Persistence.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace BookManagementSystem.Persistence.Repositories;

public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(BookManagementSystemDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<OrderItem>> GetBookOrders(Guid id)
    {
        var orders = await _dbContext.OrderItems
            .Include(x => x.Order)
            .Include(x => x.Book)
            .Where(x => x.BookID == id)
            .ToListAsync();
        return orders;
    }
}
