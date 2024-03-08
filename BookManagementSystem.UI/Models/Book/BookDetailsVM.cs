using BookManagementSystem.UI.Models.Author;
using BookManagementSystem.UI.Models.Base;

namespace BookManagementSystem.UI.Models.Book;

public class BookDetailsVM: BaseVM
{
    public AuthorDetailsVM Author { get; set; } = null!;

    public int ISBN { get; set; }

    public decimal Price { get; set; }

    public string Title { get; set; } = null!;

    public int PublicationYear { get; set; }


}
