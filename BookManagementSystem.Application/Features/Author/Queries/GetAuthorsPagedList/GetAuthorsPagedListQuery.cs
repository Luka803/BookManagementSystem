using BookManagementSystem.Application.Features.Author.Queries.GetAuthors;
using BookManagementSystem.Application.Models;
using MyDomain = BookManagementSystem.Domain;
using MediatR;

namespace BookManagementSystem.Application.Features.Author.Queries.GetAuthorsPagedList
{
    public record GetAuthorsPagedListQuery(int page) : IRequest<List<AuthorPagedListDTO>>;

}
