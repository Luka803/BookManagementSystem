using BookManagementSystem.Application.Features.Author.Queries.GetAuthors;
using BookManagementSystem.Application.Models;
using MediatR;

namespace BookManagementSystem.Application.Features.Author.Queries.GetAuthorsPagedList;

public class GetAuthorsPagedListQuery : IRequest<PagedListDTO<AuthorPagedListDTO>>
{
    public int Page { get; set; }
    public string? AuthorName { get; set; }
    public int? StartBirthYear { get; set; }
    public int? EndBirthYear { get; set; }

}
