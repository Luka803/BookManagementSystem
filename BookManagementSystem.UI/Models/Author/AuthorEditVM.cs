using BookManagementSystem.UI.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace BookManagementSystem.UI.Models.Author;

public class AuthorEditVM : BaseVM
{
    [Required]
    [MaxLength(50)]
    public string AuthorName { get; set; } = null!;
    public string Biography { get; set; } = null!;
    [Required]
    public int BirthYear { get; set; }
}
