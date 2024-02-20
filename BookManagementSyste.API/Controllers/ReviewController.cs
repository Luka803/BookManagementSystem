using BookManagementSystem.API.Controllers.Base;
using BookManagementSystem.Application.Features.Review.Queries.GetBookReviewsPagedList;
using BookManagementSystem.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementSystem.API.Controllers;

[Route("api/review")]
[ApiController]
public class ReviewController : BaseController
{
    public ReviewController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("getBookReviewsPagedList")]
    public async Task<PagedListDTO<BookReviewsPagedListDTO>> GetBookReviewsPagedList(GetBookReviewsPagedListQuery command)
    {
        return await _mediator.Send(command);
    }
}
