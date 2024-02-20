using BookManagementSystem.Application.Contracts.Persistence.Base;
using BookManagementSystem.Application.Exceptions;
using BookManagementSystem.Domain.Base;
using BookManagementSystem.Persistence.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace BookManagementSystem.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly BookManagementSystemDbContext _dbContext;

    public GenericRepository(BookManagementSystemDbContext dbContext)
    {
        this._dbContext = dbContext;
    }
    public async Task CreateAsync(T entity)
    {
        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {

        _dbContext.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T> GetAsync(Guid id)
    {
        return await _dbContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(x => x.ID == id);
    }

    public async Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}
