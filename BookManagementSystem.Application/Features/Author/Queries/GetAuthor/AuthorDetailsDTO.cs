using BookManagementSystem.Application.Models;

namespace BookManagementSystem.Application.Features.Author.Queries.GetAuthor;

public class AuthorDetailsDTO : BaseDTO
{
    public string AuthorName { get; set; } = null!;
    public string? Biography { get; set; }
    public int BirthYear { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset ModifiedDate { get; set; }

}
