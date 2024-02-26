using BookManagementSystem.API.Controllers.Base;
using BookManagementSystem.Application.Features.Review.Commands.AddReview;
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

    [HttpGet("getBookReviews{bookId}/{page}")]
    public async Task<IReadOnlyList<BookReviewsPagedListDTO>> GetBookReviewsPagedList(Guid bookId, int page = 1)
    {
        var command = new GetBookReviewsPagedListQuery(bookId, page);
        var result = await _mediator.Send(command);
        return result.Items;
    }

    [HttpPost("add")]
    public async Task<Guid> AddReview(AddReviewCommand command)
    {
        return await _mediator.Send(command);
    }
}
