using BookManagementSystem.Application.Models;
using MediatR;

namespace BookManagementSystem.Application.Features.Author.Queries.GetAuthorBooksPagedList;

public record GetAuthorBooksPagedListQuery(Guid id, int page) : IRequest<PagedListDTO<AuthorBooksDTO>>;
