using BookManagementSystem.UI.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace BookManagementSystem.UI.Models.Author;

public class AuthorBookVM : BaseVM
{
    public string Title { get; set; } = null!;
    public int ISBN { get; set; }
    public decimal Price { get; set; }

    [Display(Name = "Year of publication")]
    public int PublicationYear { get; set; }
}
