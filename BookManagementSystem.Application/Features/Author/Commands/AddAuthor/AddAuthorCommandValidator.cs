using BookManagementSystem.Application.UnitOfWork;
using FluentValidation;

namespace BookManagementSystem.Application.Features.Author.Commands.AddAuthor;

public class AddAuthorCommandValidator : AbstractValidator<AddAuthorCommand>
{
    private readonly IApplicationUnitOfWorkRepository _applicationUnitOfWorkRepository;
    public AddAuthorCommandValidator(IApplicationUnitOfWorkRepository applicationUnitOfWorkRepository)
    {
        this._applicationUnitOfWorkRepository = applicationUnitOfWorkRepository;

        RuleFor(x => x.AuthorName)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");

        RuleFor(x => x.BirthYear)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .GreaterThan(1300)
            .WithMessage("Birth year must be greater than 1300")
            .LessThan(2006)
            .WithMessage("Birth year must be less than 2006");

        RuleFor(x => x.Biography)
            .MaximumLength(500)
            .WithMessage("{PropertyName} can contain maximum of 500 characthers");

        RuleFor(x => x)
            .MustAsync(NameExist)
            .WithMessage("Author with this name already exists");
    }

    private async Task<bool> NameExist(AddAuthorCommand command, CancellationToken token)
    {
        return await _applicationUnitOfWorkRepository.Author.AuthorExist(command.AuthorName) == false;
    }

}
