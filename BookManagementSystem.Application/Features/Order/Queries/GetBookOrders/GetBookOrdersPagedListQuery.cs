using BookManagementSystem.Application.Models;
using MediatR;

namespace BookManagementSystem.Application.Features.Order.Queries.GetBookOrders;

public record GetBookOrdersPagedListQuery(Guid bookID, int page) : IRequest<PagedListDTO<BookOrderDTO>>;
