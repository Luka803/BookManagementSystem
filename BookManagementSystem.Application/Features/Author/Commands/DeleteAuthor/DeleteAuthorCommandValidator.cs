using BookManagementSystem.Application.UnitOfWork;
using FluentValidation;

namespace BookManagementSystem.Application.Features.Author.Commands.DeleteAuthor;

public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
{
    private readonly IApplicationUnitOfWorkRepository _repository;
    public DeleteAuthorCommandValidator(IApplicationUnitOfWorkRepository repository)
    {
        this._repository = repository;


    }
}
