using BookManagementSystem.Application.Models;
using MediatR;

namespace BookManagementSystem.Application.Features.Review.Queries.GetReviewsPagedList;


public record GetReviewsPagedListQuery(int page) : IRequest<PagedListDTO<GetReviewsPagedListDTO>>;
