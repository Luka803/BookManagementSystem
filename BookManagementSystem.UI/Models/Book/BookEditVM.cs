using System.ComponentModel.DataAnnotations;

namespace BookManagementSystem.UI.Models.Book;

public class BookEditVM
{
    [Required]  
    public string Title { get; set; } = null!;
    [Required]
    public Guid AuthorID { get; set; }
    [Required]
    public int ISBN { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public int PublicationYear { get; set; }
}
