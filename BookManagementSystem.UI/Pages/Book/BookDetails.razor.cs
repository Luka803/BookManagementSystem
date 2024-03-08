using BookManagementSystem.UI.Models.Author;
using BookManagementSystem.UI.Models.Book;
using Microsoft.AspNetCore.Components;

namespace BookManagementSystem.UI.Pages.Book
{
    public partial class BookDetails
    {
        [Parameter]
        public Guid bookId { get; set; }
        public BookDetailsVM Book { get; set; } = null!;
        public AuthorDetailsVM Author { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            Book = await unitOfWork.Book.GetBookWithDetails(bookId);
            Author = Book.Author;
        }

        private async void Delete()
        {
            await unitOfWork.Book.DeleteBook(bookId);
        }

        private void Edit()
        {
            navigationManager.NavigateTo("/bookedit");
        }
    }
}