using BookManagementSystem.Application.Models;
using MediatR;

namespace BookManagementSystem.Application.Features.Book.Queries.GetBooksPagedList;

public record GetBooksPagedListQuery(int page) : IRequest<PagedListDTO<BookPagedListDTO>>;
