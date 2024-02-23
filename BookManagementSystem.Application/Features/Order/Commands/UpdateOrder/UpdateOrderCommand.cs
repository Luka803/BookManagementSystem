using BookManagementSystem.Application.Features.Order.Commands.AddOrder;
using BookManagementSystem.Application.Models;
using BookManagementSystem.Domain.Enums;
using MediatR;
using MediatR.Wrappers;

namespace BookManagementSystem.Application.Features.Order.Commands.UpdateOrder;

public class UpdateOrderCommand : BaseDTO, IRequest<Guid>
{
    public Guid UserID { get; set; }
    public decimal TotalPrice => 0;
    public int TotalCount => 0;
    public ICollection<UpdateOrderItemDTO> Items { get; set; } = new List<UpdateOrderItemDTO>();
}
