using BookManagementSystem.Application.UnitOfWork;
using FluentValidation;
using MediatR;

namespace BookManagementSystem.Application.Features.User.Commands.AddUser;

public class AddUserCommand : IRequest<Guid>
{
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
}


public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
{
    private readonly IApplicationUnitOfWorkRepository _repository;

    public AddUserCommandValidator(IApplicationUnitOfWorkRepository repository)
    {
        this._repository = repository;

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("{ProperyName} is required")
            .EmailAddress();

        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage("{ProperyName} is required");

        RuleFor(x => x)
            .MustAsync(EmailAlreadyExist)
            .WithMessage("User with this e-mail already exist");
    }

    private async Task<bool> EmailAlreadyExist(AddUserCommand command, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
