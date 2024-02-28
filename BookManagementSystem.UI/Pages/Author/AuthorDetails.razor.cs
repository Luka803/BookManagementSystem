using BookManagementSystem.UI.Models.Author;
using BookManagementSystem.UI.Services.Base;
using Microsoft.AspNetCore.Components;

namespace BookManagementSystem.UI.Pages.Author;

public partial class AuthorDetails
{

    [Parameter]
    public Guid authorId { get; set; }
    public AuthorDetailsVM? AuthorDetailsVM { get; set; }
    public IReadOnlyList<AuthorBookVM>? AuthorBooks { get; set; }
    public string? ErrorResponse { get; set; }
    public string[] Routes => ["bookdetails, bookedit"];
    protected override async Task OnInitializedAsync()
    {
        await LoadAuthor();
    }
    private async Task LoadAuthor()
    {
        try
        {
            AuthorBooks = await unitOfWork.Author.GetAuthorBooks(authorId);
        }
        catch (ApiException)
        {
            ErrorResponse = "There are no books for this author";
        }
        AuthorDetailsVM = await unitOfWork.Author.GetAuthorDetails(authorId);
    }

    private void Edit(Guid authorId)
    {
        navigationManager.NavigateTo($"/authoredit/{authorId}");
    }

    private async void Delete(Guid authorId)
    {
        await unitOfWork.Author.DeleteAuthor(authorId);
        navigationManager.NavigateTo($"/authors");
    }
}