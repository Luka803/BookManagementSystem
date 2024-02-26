using BookManagementSystem.UI.Contracts;
using BookManagementSystem.UI.Services.Base;

namespace BookManagementSystem.UI.Services;

public class AuthorService : BaseHttpService, IAuthorService
{
    public AuthorService(IClient client) : base(client)
    {
    }

    public async Task<IReadOnlyList<AuthorPagedListDTO>> GetAuthors()
    {
        var authors = await _client.GetAuthorsAsync(1);
        return authors.ToList();
    }

}
