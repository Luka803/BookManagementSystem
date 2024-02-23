using BookManagementSystem.Application.Models;
using MediatR;

namespace BookManagementSystem.Application.Features.Order.Queries.GetUserOrdersPagedList;

public record GetUserOrdersPagedListQuery(Guid userId, int page) : IRequest<PagedListDTO<UserOrdersDTO>>;
