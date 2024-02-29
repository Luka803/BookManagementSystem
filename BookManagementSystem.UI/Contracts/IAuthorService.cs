using BookManagementSystem.UI.Models.Author;
using BookManagementSystem.UI.Services.Base;


namespace BookManagementSystem.UI.Contracts;

public interface IAuthorService
{
    public Task<IReadOnlyList<AuthorPagedListVM>> GetAuthors(AuthorIndexVM author);
    public Task<int> GetAuthorTotalPages();
    public Task<int> GetAuthorTotalItems();
    public Task<AuthorDetailsVM> GetAuthorDetails(Guid id);
    public Task<AuthorEditVM> GetAuthorEdit(Guid id);
    public Task<IReadOnlyList<AuthorBookVM>> GetAuthorBooks(Guid authorId);
    public Task<Guid> AddAuthor(AuthorAddVM author);
    public Task DeleteAuthor(Guid id);
    public Task<Guid> UpdateAuthor(AuthorEditVM author);
}
