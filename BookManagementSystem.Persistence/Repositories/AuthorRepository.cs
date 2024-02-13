using BookManagementSystem.Application.Contracts.Persistence;
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
}
