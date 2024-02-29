using BookManagementSystem.UI.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace BookManagementSystem.UI.Models.Author
{
    public class AuthorAddVM : BaseVM
    {
        [Required]
        public string AuthorName { get; set; } = null!;
        public string Biography { get; set; } = string.Empty;
        [Required]
        public int BirthYear { get; set; }
    }
}
