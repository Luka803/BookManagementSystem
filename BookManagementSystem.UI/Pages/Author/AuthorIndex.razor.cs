using BookManagementSystem.UI.Services.Base;
using Microsoft.AspNetCore.Components;

namespace BookManagementSystem.UI.Pages.Author
{
    public partial class AuthorIndex
    {
        private IReadOnlyList<AuthorPagedListDTO>? Authors { get; set; }
        private int? TotalPages { get; set; }
        private int Page { get; set; } = 1;

        protected override async Task OnInitializedAsync()
        {
            Authors = await unitOfWork.Author.GetAuthors(Page);
            TotalPages = await unitOfWork.Author.GetAuthorTotalPages();
        }

        private async Task RefreshData()
        {
            Authors = await unitOfWork.Author.GetAuthors(3);
            StateHasChanged();
        }

        private void Details(Guid authorId)
        {
            navigationManager.NavigateTo($"/author/{authorId}");
        }

    }
}