using MediatR;

namespace BookManagementSystem.Application.Features.Author.Commands.DeleteAuthor;

public record DeleteAuthorCommand(Guid id) : IRequest<Unit>;

