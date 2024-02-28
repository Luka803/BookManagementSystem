using BookManagementSystem.UI.Models;
using BookManagementSystem.UI.Services.Base;
using Microsoft.AspNetCore.Components;

namespace BookManagementSystem.UI.Pages.Author;

public partial class AuthorDetails
{

    [Parameter]
    public Guid authorId { get; set; }
    public AuthorDetailsDTO? AuthorDetailsDTO { get; set; }
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
        AuthorDetailsDTO = await unitOfWork.Author.GetAuthor(authorId);
    }
}