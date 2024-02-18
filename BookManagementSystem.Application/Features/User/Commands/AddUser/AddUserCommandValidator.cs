using BookManagementSystem.Application.UnitOfWork;
using FluentValidation;

namespace BookManagementSystem.Application.Features.User.Commands.AddUser;

public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
{
    private readonly IApplicationUnitOfWorkRepository _repository;

    public AddUserCommandValidator(IApplicationUnitOfWorkRepository repository)
    {
        this._repository = repository;

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .EmailAddress();

        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");

        RuleFor(x => x)
            .MustAsync(EmailAlreadyExist)
            .WithMessage("User with this e-mail already exist");
    }

    private async Task<bool> EmailAlreadyExist(AddUserCommand command, CancellationToken token)
    {
        var result = await _repository.User.EmailAlreadyExist(command.Email);

        return result == false;
    }
}
