using MediatR;

namespace BookManagementSystem.Application.Features.Author.Commands.UpdateAuthor;

public class UpdateAuthorCommand : IRequest<Guid>
{
    public Guid ID { get; set; }
    public string AuthorName { get; set; } = null!;
    public string Biography { get; set; } = string.Empty;
    public int BirthYear { get; set; }
    public DateTime CreatedDate { get; set; }
}

