using BookManagementSystem.Application.Models;

namespace BookManagementSystem.Application.Features.Author.Queries.GetAuthors;

public class AuthorDropdownDTO : BaseDTO
{
    public string AuthorName { get; set; } = null!;
}
