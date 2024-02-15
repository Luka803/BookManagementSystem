using MediatR;

namespace BookManagementSystem.Application.Features.Book.Queries.GetBook;

public record GetBookWithDetailsQuery(Guid id) : IRequest<BookWithDetailsDTO>;
