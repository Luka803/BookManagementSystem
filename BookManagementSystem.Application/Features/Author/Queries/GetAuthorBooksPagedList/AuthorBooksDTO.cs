using BookManagementSystem.Application.Models;

namespace BookManagementSystem.Application.Features.Author.Queries.GetAuthorBooksPagedList;

public class AuthorBooksDTO : BaseDTO
{
    public string Title { get; set; } = null!;
    public int ISBN { get; set; }
    public decimal Price { get; set; }
    public int PublicationYear { get; set; }

}
