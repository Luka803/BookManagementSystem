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

    [HttpGet("getWithDetails")]
    public async Task<BookWithDetailsDTO> GetBookWithDetails(GetBookWithDetailsQuery command)
    {
        return await _mediator.Send(command);
    }

    [HttpGet("getWithDetilsPagedList")]
    public async Task<PagedListDTO<BookPagedListDTO>> GetBooksWithDetailsPagedList(GetBooksPagedListQuery command)
    {
        return await _mediator.Send(command);
    }

    [HttpGet("getDropdown")]
    public async Task<List<BookDropDownDTO>> GetBooksDropDown()
    {
        return await _mediator.Send(new GetBooksDropDownQuery());
    }

    [HttpGet("getAuthorBooksPagedList")]
    public async Task<PagedListDTO<AuthorBooksDTO>> GetAuthorBooks(GetAuthorBooksPagedListQuery command)
    {
        return await _mediator.Send(command);
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

    [HttpDelete("delete")]

    public async Task<ActionResult<Unit>> DeleteBook(DeleteBookCommand command)
    {
        return await _mediator.Send(command);
    }

}
