using BookManagementSystem.Application.Contracts.Persistence;
using BookManagementSystem.Domain;
using BookManagementSystem.Persistence.DataBaseContext;

namespace BookManagementSystem.Persistence.Repositories;

public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
{
    public AuthorRepository(BookManagementSystemDbContext dbContext) : base(dbContext)
    {
    }

}
