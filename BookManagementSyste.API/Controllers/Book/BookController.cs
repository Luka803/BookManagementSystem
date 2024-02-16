using BookManagementSystem.API.Controllers.Base;
using BookManagementSystem.Application.Features.Book.Queries.GetBook;
using BookManagementSystem.Application.Features.Book.Queries.GetBookReviewsPagedList;
using BookManagementSystem.Application.Features.Book.Queries.GetBooksDropDown;
using BookManagementSystem.Application.Features.Book.Queries.GetBooksPagedList;
using BookManagementSystem.Application.Models;
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

    [HttpGet("getBooksWithDetilsPagedList{page}")]
    public async Task<PagedListDTO<BookPagedListDTO>> GetBooksWithDetailsPagedList(int page = 1)
    {
        return await _mediator.Send(new GetBooksPagedListQuery(page));
    }

    [HttpGet("getBooksDropDown")]
    public async Task<List<BookDropDownDTO>> GetBooksDropDown()
    {
        return await _mediator.Send(new GetBooksDropDownQuery());
    }

    [HttpGet("getBookReviewsPagedList{bookId}/{page}")]
    public async Task<PagedListDTO<BookReviewsPagedListDTO>> GetBookReviewsPagedList(Guid bookId, int page)
    {
        return await _mediator.Send(new GetBookReviewsPagedListQuery(bookId, page));
    }

}
