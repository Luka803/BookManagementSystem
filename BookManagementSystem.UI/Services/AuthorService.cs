using BookManagementSystem.UI.Contracts;
using BookManagementSystem.UI.Services.Base;

namespace BookManagementSystem.UI.Services;

public class AuthorService : BaseHttpService, IAuthorService
{
    public AuthorService(IClient client) : base(client)
    {
    }

    public async Task<AuthorDetailsDTO> GetAuthor(Guid id)
    {
        return await _client.GetAsync(id);
    }

    public async Task<IReadOnlyList<AuthorPagedListDTO>> GetAuthors(int page)
    {
        var authors = await _client.GetAuthorsAsync(page);
        return authors.ToList();
    }

    public async Task<int> GetAuthorTotalPages()
    {
        return await _client.GetAuthorTotalPagesAsync();
    }
}
