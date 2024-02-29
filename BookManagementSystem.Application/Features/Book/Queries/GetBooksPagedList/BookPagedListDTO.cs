using BookManagementSystem.Application.Models;

namespace BookManagementSystem.Application.Features.Book.Queries.GetBooksPagedList;

public class BookPagedListDTO : BaseDTO
{
    public string Title { get; set; } = null!;
    public int PublicationYear { get; set; }
    public decimal Price { get; set; }
}
