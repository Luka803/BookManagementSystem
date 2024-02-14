using BookManagementSystem.Application.Features.Author.Queries.GetAuthors;
using BookManagementSystem.Application.Models;
using MediatR;

namespace BookManagementSystem.Application.Features.Author.Queries.GetAuthorBooks;

public record GetAuthorBooksQuery(Guid id, int page) : IRequest<PagedListDTO<AuthorBooksDTO>>;
