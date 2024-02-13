﻿using AutoMapper;
using BookManagementSystem.Application.Contracts.Logging;
using BookManagementSystem.Application.Contracts.UnitOfWork;
using BookManagementSystem.Application.Exceptions;
using BookManagementSystem.Application.Features.Base;
using MyDomain = BookManagementSystem.Domain;

namespace BookManagementSystem.Application.Features.Author.Commands.UpdateAuthor;

public class UpdateAuthorCommandHandler : BaseRequestHandler<UpdateAuthorCommand, Guid>
{
    public UpdateAuthorCommandHandler(IMapper mapper, IApplicationUnitOfWorkCache cache, IApplicationUnitOfWorkRepository repository, IAppLogger<BaseRequestHandler<UpdateAuthorCommand, Guid>> logger) : base(mapper, cache, repository, logger)
    {
    }

    protected override async Task<Guid> HandleCore(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateAuthorCommandValidator(_repository);
        var validatonResult = await validator.ValidateAsync(request, cancellationToken);

        if (validatonResult.Errors.Any())
        {
            throw new FluentValidationException("Validation errors", validatonResult);
        }

        var entity = _mapper.Map<MyDomain.Author>(request);

        await _repository.Author.UpdateAsync(entity);

        return entity.ID;

    }
}
