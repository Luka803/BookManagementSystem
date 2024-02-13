using BookManagementSystem.Application.Contracts.UnitOfWork;
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
            .WithMessage("{ProperyName} is required");

        RuleFor(x => x)
            .MustAsync(NameExist)
            .WithMessage("Author with this name already exists");
    }

    private async Task<bool> NameExist(AddAuthorCommand command, CancellationToken token)
    {
        return await _applicationUnitOfWorkRepository.Author.AuthorExist(command.AuthorName) == false;
    }

}
