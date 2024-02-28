using AutoMapper;
using BookManagementSystem.UI.Contracts;
using BookManagementSystem.UI.Services;
using BookManagementSystem.UI.Services.Base;

namespace BookManagementSystem.UI.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    protected readonly IClient _client;
    protected readonly IMapper _mapper;
    public UnitOfWork(IClient client, IMapper mapper)
    {
        this._client = client;
        this._mapper = mapper;
    }
    protected IAuthorService? _Author;
    public IAuthorService Author
    {
        get
        {
            return _Author ?? (_Author = new AuthorService(_client, _mapper));
        }
    }
}
