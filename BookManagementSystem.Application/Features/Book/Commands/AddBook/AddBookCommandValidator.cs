using BookManagementSystem.Application.UnitOfWork;
using FluentValidation;

namespace BookManagementSystem.Application.Features.Book.Commands.AddBook;

public class AddBookCommandValidator : AbstractValidator<AddBookCommand>
{
    private readonly IApplicationUnitOfWorkRepository _repository;

    public AddBookCommandValidator(IApplicationUnitOfWorkRepository repository)
    {
        this._repository = repository;

    }


}
