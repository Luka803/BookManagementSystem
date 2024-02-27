using BookManagementSystem.UI.Contracts;
using BookManagementSystem.UI.Services;
using BookManagementSystem.UI.Services.Base;

namespace BookManagementSystem.UI.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    protected readonly IClient _client;
    public UnitOfWork(IClient client)
    {
        this._client = client;
    }
    protected IAuthorService? _Author;
    public IAuthorService Author
    {
        get
        {
            return _Author ?? (_Author = new AuthorService(_client));
        }
    }
}
