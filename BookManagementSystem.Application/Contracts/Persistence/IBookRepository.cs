using BookManagementSystem.Application.Contracts.Persistence.Base;
using BookManagementSystem.Domain;

namespace BookManagementSystem.Application.Contracts.Persistence;

public interface IBookRepository : IGenericRepository<Book>
{
    public Task<Book> GetBookWithDetails(Guid id);
    public Task<List<Book>> GetBooksWithDetails();
}



