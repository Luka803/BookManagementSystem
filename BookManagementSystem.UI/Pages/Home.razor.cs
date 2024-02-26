using BookManagementSystem.UI.Services.Base;

namespace BookManagementSystem.UI.Pages
{
    public partial class Home
    {
        public IReadOnlyList<AuthorPagedListDTO>? Authors { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Authors = await unitOfWork.Author.GetAuthors();
        }
    }
}