using BookManagementSystem.Application.Models;

namespace BookManagementSystem.Application.Features.Author.Queries.GetAuthors;

public class AuthorPagedListDTO : BaseDTO
{
    public string AuthorName { get; set; } = null!;
    public string Biography { get; set; } = string.Empty;
    public int BirthYear { get; set; }
}
