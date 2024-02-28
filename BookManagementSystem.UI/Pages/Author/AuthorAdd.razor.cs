using BookManagementSystem.UI.Models.Author;

namespace BookManagementSystem.UI.Pages.Author
{
    public partial class AuthorAdd
    {
        public AddAuthorVM Author { get; set; } = new AddAuthorVM();
        private async void HandleSubmit()
        {
            var result = await unitOfWork.Author.AddAuthor(Author!);
            navigationManager.NavigateTo($"/authordetails/{result}");
        }

    }
}