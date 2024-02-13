using BookManagementSystem.Application.Contracts.Persistence.Base;
using BookManagementSystem.Application.Features.Base;
using BookManagementSystem.Application.Models;
using BookManagementSystem.Domain.Base;
using BookManagementSystem.Persistence.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace BookManagementSystem.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly BookManagementSystemDbContext _dbContext;

    public GenericRepository(BookManagementSystemDbContext dbContext)
    {
        this._dbContext = dbContext;
    }
    public async Task CreateAsync(T entity)
    {
        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public Task DeleteAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetAsync(Guid id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public Task UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }
}
