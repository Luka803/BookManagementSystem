using BookManagementSystem.Domain.Enums;
using MediatR;

namespace BookManagementSystem.Application.Features.Order.Commands.UpdateOrderStatus;
public class UpdateOrderStatusCommand : IRequest<Guid>
{
    public Guid OrderID { get; set; }
    public OrderStatus OrderStatus { get; set; }
}
