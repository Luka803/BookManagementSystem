using BookManagementSystem.UI.Models.Order;

namespace BookManagementSystem.UI.Contracts
{
    public interface IOrderService
    {
        Task<Guid> AddOrder(OrderAddVM order);
    }
}
