using BookManagementSystem.UI.Models.Author;

namespace BookManagementSystem.UI.Pages.Author;

public partial class AuthorIndex
{
    private IReadOnlyList<AuthorPagedListVM>? Authors { get; set; }
    private AuthorIndexVM Author { get; set; } = new AuthorIndexVM();
    private int TotalPages { get; set; }
    private int TotalItems { get; set; }
    public string[]? Routes => ["authordetails", "authoredit"];

    private bool collapseNavMenu = true;
    private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;
    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }

    protected override async Task OnInitializedAsync()
    {
        await LoadData();
    }

    private async Task LoadData()
    {
        Author.Page = 1;

        Authors = await unitOfWork.Author.GetAuthors(Author!);
        TotalPages = await unitOfWork.Author.GetAuthorTotalPages();
        TotalItems = await unitOfWork.Author.GetAuthorTotalItems();
    }

    private async Task RefreshData(int page)
    {
        Author!.Page = page;
        Authors = await unitOfWork.Author.GetAuthors(Author!);
        StateHasChanged();
    }

    private void Details(Guid authorId)
    {
        navigationManager.NavigateTo($"/author/{authorId}");
    }

    private void AddAuthor()
    {
        navigationManager.NavigateTo("/author");
    }

}