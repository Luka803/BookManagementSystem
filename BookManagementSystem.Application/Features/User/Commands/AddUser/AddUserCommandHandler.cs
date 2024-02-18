using AutoMapper;
using BookManagementSystem.Application.Contracts.Logging;
using BookManagementSystem.Application.Exceptions;
using BookManagementSystem.Application.Features.Base;
using BookManagementSystem.Application.UnitOfWork;

namespace BookManagementSystem.Application.Features.User.Commands.AddUser;

public class AddUserCommandHandler : BaseRequestHandler<AddUserCommand, Guid>
{
    public AddUserCommandHandler(IMapper mapper, IApplicationUnitOfWorkCache cache, IApplicationUnitOfWorkRepository repository, IAppLogger<BaseRequestHandler<AddUserCommand, Guid>> logger) : base(mapper, cache, repository, logger)
    {
    }

    protected override async Task<Guid> HandleCore(AddUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new AddUserCommandValidator(_repository);
        var validationResult=await validator.ValidateAsync(request, cancellationToken);

        if(validationResult.Errors.Any())
        {
            throw new FluentValidationException("Validation errors", validationResult);
        }

        var entityToAdd=_mapper.Map<MyDomain.User>(request);

        await _repository.User.CreateAsync(entityToAdd);

        return entityToAdd.ID;
    }
}
