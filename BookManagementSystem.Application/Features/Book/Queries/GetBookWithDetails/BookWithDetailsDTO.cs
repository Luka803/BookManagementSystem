using BookManagementSystem.Application.Features.Author.Queries.GetAuthor;
using BookManagementSystem.Application.Models;

namespace BookManagementSystem.Application.Features.Book.Queries.GetBook;

public class BookWithDetailsDTO : BaseDTO
{
    public AuthorDetailsDTO Author { get; set; } = null!;

    public int ISBN { get; set; }

    public decimal Price { get; set; }

    public string Title { get; set; } = null!;

    public int PublicationYear { get; set; }

}
