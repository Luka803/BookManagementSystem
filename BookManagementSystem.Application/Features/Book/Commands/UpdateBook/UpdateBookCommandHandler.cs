using AutoMapper;
using BookManagementSystem.Application.Contracts.Logging;
using BookManagementSystem.Application.Exceptions;
using BookManagementSystem.Application.Features.Base;
using BookManagementSystem.Application.UnitOfWork;

namespace BookManagementSystem.Application.Features.Book.Commands.UpdateBook;

public class UpdateBookCommandHandler : BaseRequestHandler<UpdateBookCommand, Guid>
{
    public UpdateBookCommandHandler(IMapper mapper, IApplicationUnitOfWorkCache cache, IApplicationUnitOfWorkRepository repository, IAppLogger<BaseRequestHandler<UpdateBookCommand, Guid>> logger) : base(mapper, cache, repository, logger)
    {
    }

    protected override async Task<Guid> HandleCore(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateBookCommandValidator(_repository);
        var validationResul = await validator.ValidateAsync(request, cancellationToken);

        if (validationResul.Errors.Any())
            throw new FluentValidationException("Invalid type", validationResul);

        var entityToUpdate = _mapper.Map<MyDomain.Book>(request);

        await _repository.Books.UpdateAsync(entityToUpdate);

        return entityToUpdate.ID;
    }
}
