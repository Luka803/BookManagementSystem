using AutoMapper;
using BookManagementSystem.Application.Contracts.Logging;
using BookManagementSystem.Application.Contracts.UnitOfWork;
using BookManagementSystem.Application.Features.Base;
using MyDomain = BookManagementSystem.Domain;

namespace BookManagementSystem.Application.Features.Author.Commands.AddAuthor;

public class AddAuthorCommandHandler : BaseRequestHandler<AddAuthorCommand, Guid>
{
    public AddAuthorCommandHandler(IMapper mapper, IApplicationUnitOfWorkCache cache, IApplicationUnitOfWorkRepository repository, IAppLogger<BaseRequestHandler<AddAuthorCommand, Guid>> logger) : base(mapper, cache, repository, logger)
    {
    }

    protected override async Task<Guid> HandleCore(AddAuthorCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<MyDomain.Author>(request);
        await _repository.Author.CreateAsync(entity);
        return entity.ID;
    }

}
