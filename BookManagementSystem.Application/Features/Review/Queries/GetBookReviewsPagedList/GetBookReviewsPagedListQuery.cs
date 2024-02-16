using BookManagementSystem.Application.Models;
using MediatR;

namespace BookManagementSystem.Application.Features.Review.Queries.GetBookReviewsPagedList;

public record GetBookReviewsPagedListQuery(Guid Id, int page) : IRequest<PagedListDTO<BookReviewsPagedListDTO>>;
