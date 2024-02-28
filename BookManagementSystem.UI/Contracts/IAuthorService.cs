using BookManagementSystem.UI.Models;
using BookManagementSystem.UI.Services.Base;

namespace BookManagementSystem.UI.Contracts;

public interface IAuthorService
{
    public Task<IReadOnlyList<AuthorPagedListVM>> GetAuthors(int page);
    public Task<int> GetAuthorTotalPages();
    public Task<AuthorDetailsDTO> GetAuthor(Guid id);
    public Task<IReadOnlyList<AuthorBookVM>> GetAuthorBooks(Guid authorId);
    public Task DeleteAuthor(Guid id);

}
