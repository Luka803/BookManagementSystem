using BookManagementSystem.UI.Models.Book;

namespace BookManagementSystem.UI.Pages.Book
{
    public partial class BookIndex
    {
        private IReadOnlyList<BookPagedListVM>? Books { get; set; }
        private int TotalPages { get; set; }
        private int TotalItems { get; set; }
        private BookIndexVM Book { get; set; } = new BookIndexVM();
        private string[]? Routes => ["bookdetails", "bookedit"];

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            Book.Page = 1;
            Books = await unitOfWork.Book.GetBooks(Book);
            TotalPages = await unitOfWork.Book.GetBookTotalPages();
            TotalItems = await unitOfWork.Book.GetBookTotalItems();

        }
        private async void RefreshData(int page)
        {
            Book.Page = page;
            Books = await unitOfWork.Book.GetBooks(Book);
        }

        private void AddBook()
        {
            navigationManager.NavigateTo("/bookadd");
        }

        private bool collapseNavMenu = true;
        private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;
        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }


    }
}