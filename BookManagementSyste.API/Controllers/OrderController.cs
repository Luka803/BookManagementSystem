using BookManagementSystem.API.Controllers.Base;
using BookManagementSystem.Application.Features.Order.Commands.AddOrder;
using BookManagementSystem.Application.Features.Order.Commands.DeleteOrder;
using BookManagementSystem.Application.Features.Order.Commands.UpdateOrder;
using BookManagementSystem.Application.Features.Order.Commands.UpdateOrderStatus;
using BookManagementSystem.Application.Features.Order.Queries.GetUserOrdersPagedList;
using BookManagementSystem.Application.Models;
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

    [HttpDelete("deleteOrder")]
    public async Task<Unit> DeleteOrder(DeleteOrderCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPut("updateOrderStatus")]
    public async Task<Guid> UpdateOrderStatus(UpdateOrderStatusCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPut("updateOrder")]
    public async Task<Guid> UpdateOrder(UpdateOrderCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpGet("getUser{userId}/{page}")]

    public async Task<IReadOnlyList<UserOrdersDTO>> GetUserOrders(Guid userId, int page)
    {
        var command = new GetUserOrdersPagedListQuery(userId, page);
        var result = await _mediator.Send(command);
        return result.Items;

    }


}
