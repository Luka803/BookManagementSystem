using BookManagementSystem.API.Controllers.Base;
using BookManagementSystem.Application.Features.OrderItem.Queries.GetBookOrders;
using BookManagementSystem.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementSystem.API.Controllers
{
    [Route("api/orderItem")]
    [ApiController]
    public class OrderItemController : BaseController
    {
        public OrderItemController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("getBookOrders{bookId}/{page}")]
        public async Task<IReadOnlyList<BookOrderDTO>> GetBookOrders(Guid bookId, int page = 1)
        {
            var command = new GetBookOrdersPagedListQuery(bookId, page);
            var result = await _mediator.Send(command);
            return result.Items;
        }
    }
}
