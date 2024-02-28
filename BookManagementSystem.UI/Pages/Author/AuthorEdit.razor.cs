using BookManagementSystem.UI.Models.Author;
using Microsoft.AspNetCore.Components;

namespace BookManagementSystem.UI.Pages.Author
{
    public partial class AuthorEdit
    {
        [Parameter]
        public Guid authorId { get; set; }
        public AuthorEditVM Author { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            Author = await unitOfWork.Author.GetAuthorEdit(authorId);
        }

        private async Task HandleSubmit()
        {
            var authorId = await unitOfWork.Author.UpdateAuthor(Author);
            navigationManager.NavigateTo($"/authordetails/{authorId}");

        }
    }
}