using BookManagementSystem.UI.Contracts;
using BookManagementSystem.UI.Models;
using BookManagementSystem.UI.Services.Base;

namespace BookManagementSystem.UI.Services;

public class AuthorService : BaseHttpService, IAuthorService
{
    public AuthorService(IClient client) : base(client)
    {
    }

    public Task<List<AuthorVM>> GetAuthors()
    {
        throw new NotImplementedException();
    }
}
