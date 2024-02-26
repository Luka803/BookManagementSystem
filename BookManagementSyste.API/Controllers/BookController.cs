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

    [HttpGet("getBookWithDetails{bookId}")]
    public async Task<BookWithDetailsDTO> GetBookWithDetails(Guid bookId)
    {
        var command = new GetBookWithDetailsQuery(bookId);
        return await _mediator.Send(command);
    }

    [HttpGet("getBooksWithDetils{page}")]
    public async Task<IReadOnlyList<BookPagedListDTO>> GetBooksWithDetailsPagedList(int page = 1)
    {
        var command = new GetBooksPagedListQuery(page);
        var result = await _mediator.Send(command);
        return result.Items;
    }

    [HttpGet("getBooksDropdown")]
    public async Task<List<BookDropDownDTO>> GetBooksDropdown()
    {
        return await _mediator.Send(new GetBooksDropDownQuery());
    }

    [HttpGet("getAuthorBooks{authorId}/{page}")]
    public async Task<IReadOnlyList<AuthorBooksDTO>> GetAuthorBooks(Guid authorId, int page = 1)
    {
        var command = new GetAuthorBooksPagedListQuery(authorId, page);
        var result = await _mediator.Send(command);
        return result.Items;
    }


    [HttpPost("addBook")]
    public async Task<Guid> AddBook(AddBookCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPut("updateBook")]
    public async Task<Guid> UpdateBook(UpdateBookCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpDelete("deleteBook")]

    public async Task<ActionResult<Unit>> DeleteBook(DeleteBookCommand command)
    {
        return await _mediator.Send(command);
    }

}
