using AutoMapper;
using BookManagementSystem.Application.Contracts.Logging;
using BookManagementSystem.Application.Exceptions;
using BookManagementSystem.Application.Features.Base;
using BookManagementSystem.Application.UnitOfWork;
using MediatR;

namespace BookManagementSystem.Application.Features.Author.Commands.DeleteAuthor;

public class DeleteAuthorCommandHandler : BaseRequestHandler<DeleteAuthorCommand, Unit>
{
    public DeleteAuthorCommandHandler(IMapper mapper, IApplicationUnitOfWorkCache cache, IApplicationUnitOfWorkRepository repository, IAppLogger<BaseRequestHandler<DeleteAuthorCommand, Unit>> logger) : base(mapper, cache, repository, logger)
    {
    }
    protected override async Task<Unit> HandleCore(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.Author.GetAsync(request.id);

        if (entity == null)
            throw new NotFoundException(nameof(Author), request.id);

        await _repository.Author.DeleteAsync(entity);
        await _cache.AuthorCacheService.RemoveFromCache("GetAuthors");

        return Unit.Value;

    }
}

