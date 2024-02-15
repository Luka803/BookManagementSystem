using BookManagementSystem.API.Controllers.Base;
using BookManagementSystem.Application.Features.Book.Queries.GetBook;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementSystem.API.Controllers.Book;

[Route("api/book")]
[ApiController]
public class BookController : BaseController
{
    public BookController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("getSingleBookWithDetails{id}")]
    public async Task<BookWithDetailsDTO> GetBookWithDetails(Guid id)
    {
        return await _mediator.Send(new GetBookWithDetailsQuery(id));
    }
}
