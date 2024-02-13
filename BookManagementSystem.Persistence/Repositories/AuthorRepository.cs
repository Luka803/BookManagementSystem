using BookManagementSystem.Application.Contracts.Persistence;
using BookManagementSystem.Domain;
using BookManagementSystem.Persistence.DataBaseContext;

namespace BookManagementSystem.Persistence.Repositories;

public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
{
    public AuthorRepository(BookManagementSystemDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<Author>> GetAllAuthorsAsync()
    {
        await Task.CompletedTask;
        return new List<Author>()
        {
           new Author()
           {
               ID= Guid.NewGuid(),
               AuthorName="Luka Kovacevic",
               Biography="Some bio",
               BirthYear=1952
           },

        };

    }
}
