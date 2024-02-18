using BookManagementSystem.Application.Contracts.Persistence;
using BookManagementSystem.Domain;
using BookManagementSystem.Persistence.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace BookManagementSystem.Persistence.Repositories;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    public BookRepository(BookManagementSystemDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> BookNameExist(string title)
    {
        var book = await _dbContext.Books
            .SingleOrDefaultAsync(x => x.Title.ToUpper() == title.ToUpper());
        return book != null;
    }

    public async Task<List<Book>> GetBooksWithDetails()
    {
        var books = await _dbContext.Books
            .Include(x => x.Author)
            .ToListAsync();
        return books;
    }

    public async Task<Book> GetBookWithDetails(Guid id)
    {
        var book = await _dbContext.Books
            .Include(x => x.Author)
            .SingleOrDefaultAsync(x => x.ID == id);
        return book;
    }
}
