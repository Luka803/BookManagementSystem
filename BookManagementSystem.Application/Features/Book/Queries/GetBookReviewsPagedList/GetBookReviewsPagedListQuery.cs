using BookManagementSystem.Application.Models;
using MediatR;

namespace BookManagementSystem.Application.Features.Book.Queries.GetBookReviewsPagedList;

public record GetBookReviewsPagedListQuery(Guid Id, int page) : IRequest<PagedListDTO<BookReviewsPagedListDTO>>;
