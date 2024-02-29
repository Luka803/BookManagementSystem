using BookManagementSystem.UI.Models.Author;

namespace BookManagementSystem.UI.Pages.Author
{
    public partial class AuthorAdd
    {
        public AuthorAddVM Author { get; set; } = new AuthorAddVM();
        private async void HandleSubmit()
        {
            var result = await unitOfWork.Author.AddAuthor(Author!);
            navigationManager.NavigateTo($"/authordetails/{result}");
        }

    }
}