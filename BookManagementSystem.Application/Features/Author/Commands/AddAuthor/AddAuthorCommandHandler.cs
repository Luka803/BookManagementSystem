using AutoMapper;
using BookManagementSystem.Application.Contracts.Logging;
using BookManagementSystem.Application.Exceptions;
using BookManagementSystem.Application.Features.Base;
using BookManagementSystem.Application.UnitOfWork;

namespace BookManagementSystem.Application.Features.Author.Commands.AddAuthor;

public class AddAuthorCommandHandler : BaseRequestHandler<AddAuthorCommand, Guid>
{
    public AddAuthorCommandHandler(IMapper mapper, IApplicationUnitOfWorkCache cache, IApplicationUnitOfWorkRepository repository, IAppLogger<BaseRequestHandler<AddAuthorCommand, Guid>> logger) : base(mapper, cache, repository, logger)
    {
    }

    protected override async Task<Guid> HandleCore(AddAuthorCommand request, CancellationToken cancellationToken)
    {
        var validator = new AddAuthorCommandValidator(_repository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
        {
            foreach (var item in validationResult.Errors)
            {
                _logger.LogWarning(item.ErrorMessage, item);
            }
            throw new FluentValidationException("Invalid type", validationResult);
        }

        var entity = _mapper.Map<MyDomain.Author>(request);

        await _repository.Author.CreateAsync(entity);


        return entity.ID;
    }

}
