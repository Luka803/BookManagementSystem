using BookManagementSystem.Domain.Enums;
using MediatR;

namespace BookManagementSystem.Application.Features.Order.Commands.AddOrder;
public class AddOrderCommand : IRequest<Guid>
{
    public Guid UserID { get; set; }
    public decimal TotalPrice => 0;
    public int TotalCount => 0;

    public OrderStatus Status = OrderStatus.Created;
    public ICollection<AddOrderItemDTO> Items { get; set; } = new List<AddOrderItemDTO>();

}



