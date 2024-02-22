using AutoMapper;
using BookManagementSystem.Application.Contracts.Logging;
using BookManagementSystem.Application.Features.Base;
using BookManagementSystem.Application.UnitOfWork;
using MediatR;

namespace BookManagementSystem.Application.Features.Book.Commands.DeleteBook;

public class DeleteBookCommandHandler : BaseRequestHandler<DeleteBookCommand, Unit>
{
    public DeleteBookCommandHandler(IMapper mapper, IApplicationUnitOfWorkCache cache, IApplicationUnitOfWorkRepository repository, IAppLogger<BaseRequestHandler<DeleteBookCommand, Unit>> logger) : base(mapper, cache, repository, logger)
    {
    }

    protected override async Task<Unit> HandleCore(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var entityToDelete = await _repository.Books.GetAsync(request.id);

        await _repository.Books.DeleteAsync(entityToDelete);
        await _cache.BookCacheService.RemoveFromCache("GetBooks");

        return Unit.Value;
    }
}

