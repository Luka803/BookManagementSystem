﻿using AutoMapper;
using BookManagementSystem.Application.Contracts.Logging;
using BookManagementSystem.Application.Features.Base;
using BookManagementSystem.Application.UnitOfWork;

namespace BookManagementSystem.Application.Features.Book.Commands.AddBook;

public class AddBookCommandHandler : BaseRequestHandler<AddBookCommand, Guid>
{
    public AddBookCommandHandler(IMapper mapper, IApplicationUnitOfWorkCache cache, IApplicationUnitOfWorkRepository repository, IAppLogger<BaseRequestHandler<AddBookCommand, Guid>> logger) : base(mapper, cache, repository, logger)
    {
    }

    protected override async Task<Guid> HandleCore(AddBookCommand request, CancellationToken cancellationToken)
    {
        var validator = new AddBookCommandValidator(_repository);
        var validatonResult = await validator.ValidateAsync(request, cancellationToken);

        if (validatonResult.Errors.Any())
            throw new FluentValidationException("Validation errors", validatonResult);

        var entityToCreate = _mapper.Map<MyDomain.Book>(request);

        await _repository.Books.CreateAsync(entityToCreate);
        await _cache.BookCacheService.RemoveFromCache("GetBooks");

        return entityToCreate.ID;
    }
}
