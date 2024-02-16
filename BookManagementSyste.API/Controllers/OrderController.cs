using BookManagementSystem.API.Controllers.Base;
using BookManagementSystem.Application.Features.Order.Commands.AddOrder;
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
}
