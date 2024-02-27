using BookManagementSystem.UI.Services.Base;
using Microsoft.AspNetCore.Components;

namespace BookManagementSystem.UI.Pages.Author;

public partial class AuthorDetails
{

    [Parameter]
    public Guid authorId { get; set; }
    public AuthorDetailsDTO? AuthorDetailsDTO { get; set; }
    protected override async Task OnInitializedAsync()
    {
        await LoadAuthor();
    }

    private async Task LoadAuthor()
    {
        AuthorDetailsDTO = await unitOfWork.Author.GetAuthor(authorId);
    }
}