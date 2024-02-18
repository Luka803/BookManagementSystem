using BookManagementSystem.Application.Contracts.Persistence;
using BookManagementSystem.Domain;
using BookManagementSystem.Persistence.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace BookManagementSystem.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(BookManagementSystemDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> EmailAlreadyExist(string email)
    {
        var emailExist = await _dbContext.Users
            .SingleOrDefaultAsync(x => x.Email == email);

        return emailExist != null;
    }
}
