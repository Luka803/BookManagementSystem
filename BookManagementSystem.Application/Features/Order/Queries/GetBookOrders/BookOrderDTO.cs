using BookManagementSystem.Application.Features.Order.Commands.AddOrder;
using BookManagementSystem.Application.Models;
using BookManagementSystem.Domain.Enums;

namespace BookManagementSystem.Application.Features.Order.Queries.GetBookOrders
{
    public class BookOrderDTO : BaseDTO
    {
        public string Title { get; set; } = null!;
        public Guid BookID { get; set; }
        public Guid OrderItemID { get; set; }
        public Guid OrderID { get; set; }
        public DateTime CreatedDate { get; set; }
        public OrderStatus Status { get; set; }
        public ICollection<AddOrderItemDTO> Items { get; set; } = new List<AddOrderItemDTO>();
    }
}
