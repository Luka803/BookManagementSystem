using BookManagementSystem.UI.Models.Author;
using BookManagementSystem.UI.Services.Base;

namespace BookManagementSystem.UI.Contracts;

public interface IAuthorService
{
    public Task<IReadOnlyList<AuthorPagedListVM>> GetAuthors(int page);
    public Task<int> GetAuthorTotalPages();
    public Task<AuthorDetailsVM> GetAuthorDetails(Guid id);
    public Task<AuthorEditVM> GetAuthorEdit(Guid id);
    public Task<IReadOnlyList<AuthorBookVM>> GetAuthorBooks(Guid authorId);
    public Task DeleteAuthor(Guid id);
    public Task<Guid> UpdateAuthor(AuthorEditVM author);

}
