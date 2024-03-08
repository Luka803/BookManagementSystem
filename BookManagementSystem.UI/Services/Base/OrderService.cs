using AutoMapper;
using BookManagementSystem.UI.Contracts;
using BookManagementSystem.UI.Models.Order;

namespace BookManagementSystem.UI.Services.Base
{
    public class OrderService : BaseHttpService, IOrderService
    {
        public OrderService(IClient client, IMapper mapper) : base(client, mapper)
        {
        }

        public async Task<Guid> AddOrder(OrderAddVM order)
        {
            var orderToAdd=_mapper.Map<AddOrderCommand>(order);
            return await _client.AddOrderAsync(orderToAdd);
        }
    }
}
