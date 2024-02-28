using AutoMapper;
using BookManagementSystem.UI.Contracts;
using BookManagementSystem.UI.Models;
using BookManagementSystem.UI.Services.Base;

namespace BookManagementSystem.UI.Services;

public class AuthorService : BaseHttpService, IAuthorService
{
    public AuthorService(IClient client, IMapper mapper) : base(client, mapper)
    {
    }

    public Task DeleteAuthor(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<AuthorDetailsDTO> GetAuthor(Guid id)
    {
        return await _client.GetAsync(id);
    }

    public async Task<IReadOnlyList<AuthorBookVM>> GetAuthorBooks(Guid authorId)
    {

        var authorBooks = await _client.BookAll2Async(authorId, 1);
        return _mapper.Map<IReadOnlyList<AuthorBookVM>>(authorBooks);
    }

    public async Task<IReadOnlyList<AuthorPagedListVM>> GetAuthors(int page)
    {
        var authors = await _client.GetAuthorsAsync(page);
        return _mapper.Map<IReadOnlyList<AuthorPagedListVM>>(authors);
    }

    public async Task<int> GetAuthorTotalPages()
    {
        return await _client.GetAuthorTotalPagesAsync();
    }
}
