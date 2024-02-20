using BookManagementSystem.API.Controllers.Base;
using BookManagementSystem.Application.Features.Author.Queries.GetAuthorBooksPagedList;
using BookManagementSystem.Application.Features.Book.Commands.AddBook;
using BookManagementSystem.Application.Features.Book.Commands.DeleteBook;
using BookManagementSystem.Application.Features.Book.Commands.UpdateBook;
using BookManagementSystem.Application.Features.Book.Queries.GetBook;
using BookManagementSystem.Application.Features.Book.Queries.GetBooksDropDown;
using BookManagementSystem.Application.Features.Book.Queries.GetBooksPagedList;
using BookManagementSystem.Application.Features.Review.Queries.GetBookReviewsPagedList;
using BookManagementSystem.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementSystem.API.Controllers;

[Route("api/book")]
[ApiController]
public class BookController : BaseController
{
    public BookController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("getWithDetails{Id}")]
    public async Task<BookWithDetailsDTO> GetBookWithDetails(Guid id)
    {
        return await _mediator.Send(new GetBookWithDetailsQuery(id));
    }

    [HttpGet("getWithDetilsPagedList{page}")]
    public async Task<PagedListDTO<BookPagedListDTO>> GetBooksWithDetailsPagedList(int page = 1)
    {
        return await _mediator.Send(new GetBooksPagedListQuery(page));
    }

    [HttpGet("getDropdown")]
    public async Task<List<BookDropDownDTO>> GetBooksDropDown()
    {
        return await _mediator.Send(new GetBooksDropDownQuery());
    }

    [HttpGet("getAuthorBooksPagedList{authorId}/{page}")]
    public async Task<PagedListDTO<AuthorBooksDTO>> GetAuthorBooks(Guid authorId, int page = 1)
    {
        return await _mediator.Send(new GetAuthorBooksPagedListQuery(authorId, page));
    }

    [HttpPost("add")]
    public async Task<Guid> AddBook(AddBookCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPut("update")]
    public async Task<Guid> UpdateBook(UpdateBookCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpDelete("delete{Id}")]

    public async Task<ActionResult<Unit>> DeleteBook(Guid id)
    {
        return await _mediator.Send(new DeleteBookCommand(id));
    }

}
