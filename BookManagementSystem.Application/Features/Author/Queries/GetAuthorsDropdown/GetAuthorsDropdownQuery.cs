using MediatR;

namespace BookManagementSystem.Application.Features.Author.Queries.GetAuthors;

public class GetAuthorsDropdownQuery : IRequest<List<AuthorDropdownDTO>>
{
}
