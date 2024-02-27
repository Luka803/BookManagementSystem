using BookManagementSystem.UI.Models.Base;

namespace BookManagementSystem.UI.Models
{
    public class AuthorPagedListVM : BaseVM, IBaseTableModel
    {
        public string AuthorName { get; set; } = null!;
        public string Biography { get; set; } = string.Empty;
        public int BirthYear { get; set; }
    }
}
