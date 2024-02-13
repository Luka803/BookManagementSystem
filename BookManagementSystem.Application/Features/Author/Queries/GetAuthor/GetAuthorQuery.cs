using MediatR;

namespace BookManagementSystem.Application.Features.Author.Queries.GetAuthor;

public record GetAuthorQuery(Guid ID) : IRequest<AuthorDetailsDTO>;
