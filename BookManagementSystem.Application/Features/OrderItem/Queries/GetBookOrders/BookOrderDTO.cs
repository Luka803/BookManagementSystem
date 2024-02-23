using BookManagementSystem.Application.Models;
using BookManagementSystem.Domain.Enums;

namespace BookManagementSystem.Application.Features.OrderItem.Queries.GetBookOrders;

public class BookOrderDTO : BaseDTO
{
    public Guid BookID { get; set; }
    public Guid OrderID { get; set; }
    public int Count { get; set; }
    public int ItemNumber { get; set; }
    public DateTime CreatedDate { get; set; }
    public OrderStatus Status { get; set; }
}
