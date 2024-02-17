using BookManagementSystem.API.Controllers.Base;
using BookManagementSystem.Application.Features.Order.Commands.AddOrder;
using BookManagementSystem.Application.Features.Order.Commands.DeleteOrder;
using BookManagementSystem.Application.Features.Order.Commands.UpdateOrderStatus;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementSystem.API.Controllers;

[Route("api/order")]
[ApiController]
public class OrderController : BaseController
{
    public OrderController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("addOrder")]
    public async Task<Guid> AddOrder(AddOrderCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpDelete("deleteOrder{orderId}")]
    public async Task<Unit> DeleteOrder(Guid id)
    {
        var command = new DeleteOrderCommand(id);
        return await _mediator.Send(command);
    }

    [HttpPut("updateOrderStatus")]
    public async Task<Guid> UpdateOrderStatus(UpdateOrderStatusCommand command)
    {
        return await _mediator.Send(command);
    }
}
