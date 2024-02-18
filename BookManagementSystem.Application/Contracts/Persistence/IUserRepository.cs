using BookManagementSystem.Application.Contracts.Persistence.Base;
using BookManagementSystem.Domain;

namespace BookManagementSystem.Application.Contracts.Persistence;

public interface IUserRepository : IGenericRepository<User>
{
    public Task<bool> EmailAlreadyExist(string email);
}



