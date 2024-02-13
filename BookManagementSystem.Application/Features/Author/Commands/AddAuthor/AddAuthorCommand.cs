using MediatR;

namespace BookManagementSystem.Application.Features.Author.Commands.AddAuthor;

public class AddAuthorCommand : IRequest<Guid>
{
    public string AuthorName { get; set; } = null!;
    public string Biography { get; set; } = string.Empty;
    public int BirthYear { get; set; }

}
