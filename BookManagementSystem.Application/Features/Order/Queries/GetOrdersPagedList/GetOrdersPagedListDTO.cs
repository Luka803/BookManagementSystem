using BookManagementSystem.Application.Models;
using BookManagementSystem.Domain.Enums;

namespace BookManagementSystem.Application.Features.Order.Queries.GetOrdersPagedList;

public class GetOrdersPagedListDTO : BaseDTO
{
    public DateTime DateCreated { get; set; }

    public OrderStatus Status { get; set; }
}
