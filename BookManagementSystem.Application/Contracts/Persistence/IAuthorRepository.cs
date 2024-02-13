using BookManagementSystem.Application.Contracts.Persistence.Base;
using BookManagementSystem.Domain;


namespace BookManagementSystem.Application.Contracts.Persistence;

public interface IAuthorRepository : IGenericRepository<Author>
{
    public Task<bool> AuthorExist(string name);
}



