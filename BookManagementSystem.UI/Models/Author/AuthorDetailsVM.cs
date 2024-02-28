using BookManagementSystem.UI.Models.Base;

namespace BookManagementSystem.UI.Models.Author
{
    public class AuthorDetailsVM : BaseVM
    {
        public string AuthorName { get; set; } = null!;
        public string? Biography { get; set; }
        public int BirthYear { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }

        public string GetFormattedCreatedDate()
        {
            return CreatedDate.ToString("dd.MM.yyyy HH:mm:ss");
        }

        public string GetFormattedModifiedDate()
        {
            return ModifiedDate.ToString("dd.MM.yyyy HH:mm:ss");
        }
    }
}
