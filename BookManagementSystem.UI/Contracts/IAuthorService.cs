using BookManagementSystem.UI.Models;
using BookManagementSystem.UI.Services.Base;

namespace BookManagementSystem.UI.Contracts;

public interface IAuthorService
{
    public Task<IReadOnlyList<AuthorPagedListDTO>> GetAuthors();
}
