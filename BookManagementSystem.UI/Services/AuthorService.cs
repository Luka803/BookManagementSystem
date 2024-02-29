using AutoMapper;
using BookManagementSystem.UI.Contracts;
using BookManagementSystem.UI.Models.Author;
using BookManagementSystem.UI.Services.Base;

namespace BookManagementSystem.UI.Services;

public class AuthorService : BaseHttpService, IAuthorService
{
    public AuthorService(IClient client, IMapper mapper) : base(client, mapper)
    {
    }

    public async Task DeleteAuthor(Guid id)
    {
        var command = new DeleteAuthorCommand
        {
            Id = id
        };
        await _client.DeleteAuthorAsync(command);
    }

    public async Task<AuthorDetailsVM> GetAuthorDetails(Guid id)
    {
        var author = await _client.GetAsync(id);
        return _mapper.Map<AuthorDetailsVM>(author);
    }

    public async Task<IReadOnlyList<AuthorBookVM>> GetAuthorBooks(Guid authorId)
    {

        var authorBooks = await _client.BookAll2Async(authorId, 1);
        return _mapper.Map<IReadOnlyList<AuthorBookVM>>(authorBooks);
    }

    public async Task<IReadOnlyList<AuthorPagedListVM>> GetAuthors(AuthorIndexVM author)
    {
        var authorToSend = _mapper.Map<GetAuthorsPagedListQuery>(author);
        var authors = await _client.GetAuthorsAsync(authorToSend);
        return _mapper.Map<IReadOnlyList<AuthorPagedListVM>>(authors);
    }

    public async Task<int> GetAuthorTotalPages()
    {
        return await _client.GetAuthorTotalPagesAsync();
    }

    public async Task<AuthorEditVM> GetAuthorEdit(Guid id)
    {
        var author = await _client.GetAsync(id);
        return _mapper.Map<AuthorEditVM>(author);
    }

    public async Task<Guid> UpdateAuthor(AuthorEditVM author)
    {
        var authorToAdd = _mapper.Map<UpdateAuthorCommand>(author);
        return await _client.UpdateAuthorAsync(authorToAdd);
    }

    public async Task<Guid> AddAuthor(AuthorAddVM author)
    {
        var authorToAdd = _mapper.Map<AddAuthorCommand>(author);
        var result = await _client.AddAuthorAsync(authorToAdd);
        return result;
    }

    public async Task<int> GetAuthorTotalItems()
    {
        return await _client.GetAuthorTotalItemsAsync();
    }

    public async Task<ICollection<AuthorDropdownDTO>> GetAuthorsDropdown()
    {
        return await _client.GetAuthorsDropdownAsync();
    }
}
