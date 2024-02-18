using BookManagementSystem.Application.Contracts.Persistence;
using BookManagementSystem.Domain;
using BookManagementSystem.Persistence.DataBaseContext;

namespace BookManagementSystem.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(BookManagementSystemDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> EmailAlreadyExist(Guid id, string email)
    {
        await Task.CompletedTask;
        return true;
    }
}
