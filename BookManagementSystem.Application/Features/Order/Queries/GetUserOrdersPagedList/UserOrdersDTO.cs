using BookManagementSystem.Application.Features.Book.Queries.GetBooksPagedList;
using BookManagementSystem.Application.Models;
using BookManagementSystem.Domain.Enums;

namespace BookManagementSystem.Application.Features.Order.Queries.GetUserOrdersPagedList;

public class UserOrdersDTO : BaseDTO
{
    public Guid OrderID { get; set; }

    public decimal TotalPrice { get; set; }

    public int TotalCount { get; set; }

    public OrderStatus Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime ModifiedDate { get; set; }
}
