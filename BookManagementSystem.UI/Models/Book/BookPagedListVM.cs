using System.ComponentModel.DataAnnotations;
using BookManagementSystem.UI.Models.Base;

namespace BookManagementSystem.UI.Models.Book;

public class BookPagedListVM : BaseVM
{
    [Display(Name = "Book title")]
    public string Title { get; set; } = null!;

    [Display(Name = "Year of publication")]
    public int PublicationYear { get; set; }
    public decimal Price { get; set; }
}

