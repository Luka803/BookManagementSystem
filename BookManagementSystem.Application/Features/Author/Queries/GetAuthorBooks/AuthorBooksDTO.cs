using BookManagementSystem.Application.Features.Base;

namespace BookManagementSystem.Application.Features.Author.Queries.GetAuthorBooks;

public class AuthorBooksDTO : BaseDTO
{
    public string Title { get; set; } = null!;
    public int ISBN { get; set; }
    public decimal Price { get; set; }
    public int PublicationYear { get; set; }

}
