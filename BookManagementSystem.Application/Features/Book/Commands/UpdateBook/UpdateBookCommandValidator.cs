using BookManagementSystem.Application.UnitOfWork;
using FluentValidation;

namespace BookManagementSystem.Application.Features.Book.Commands.UpdateBook;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    protected readonly IApplicationUnitOfWorkRepository _repository;
    public UpdateBookCommandValidator(IApplicationUnitOfWorkRepository repository)
    {
        this._repository = repository;


    }
}
