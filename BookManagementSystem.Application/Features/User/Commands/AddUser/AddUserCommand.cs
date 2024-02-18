using MediatR;

namespace BookManagementSystem.Application.Features.User.Commands.AddUser;

public class AddUserCommand : IRequest<Guid>
{
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
}
