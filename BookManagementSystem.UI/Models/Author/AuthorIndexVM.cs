using System.ComponentModel.DataAnnotations;

namespace BookManagementSystem.UI.Models.Author
{
    public class AuthorIndexVM
    {
        [Required]
        public int Page { get; set; }
        public string? AuthorName { get; set; }
        public int? StartBirthYear { get; set; }
        public int? EndBirthYear { get; set; }
    }
}
