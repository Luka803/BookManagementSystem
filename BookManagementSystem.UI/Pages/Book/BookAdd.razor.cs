using BookManagementSystem.UI.Models.Book;
using BookManagementSystem.UI.Services.Base;

namespace BookManagementSystem.UI.Pages.Book
{
    public partial class BookAdd
    {
        public BookAddVM Book { get; set; } = new BookAddVM();

        public ICollection<AuthorDropdownDTO> Authors { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            Authors = await unitOfWork.Author.GetAuthorsDropdown();
        }

        private async void AddBook()
        {
            var result = await unitOfWork.Book.AddBook(Book);
        }

    }
}