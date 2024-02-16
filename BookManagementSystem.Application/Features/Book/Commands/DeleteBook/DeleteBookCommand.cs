using MediatR;

namespace BookManagementSystem.Application.Features.Book.Commands.DeleteBook;

public record DeleteBookCommand(Guid id) : IRequest<Unit>;

