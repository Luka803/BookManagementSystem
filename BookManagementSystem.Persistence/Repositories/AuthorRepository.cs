using BookManagementSystem.Application.Contracts.Persistence;
using BookManagementSystem.Application.Exceptions;
using BookManagementSystem.Domain;
using BookManagementSystem.Persistence.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace BookManagementSystem.Persistence.Repositories;

public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
{
    public AuthorRepository(BookManagementSystemDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> AuthorExist(string name)
    {
        var author = await _dbContext
            .Set<Author>()
            .SingleOrDefaultAsync(x => x.AuthorName.ToLower() == name.ToLower());
        return author != null;
    }

    public async Task<List<Book>> GetAuthorBooks(Guid id)
    {
        var authorBooks = await _dbContext.Set<Author>()
            .Include(x => x.Books)
            .FirstOrDefaultAsync(x => x.ID == id);

        if (authorBooks.Books.Any())
        {
            return authorBooks.Books.ToList();
        }
        throw new NotFoundException("The books for author with", id);
    }
}
