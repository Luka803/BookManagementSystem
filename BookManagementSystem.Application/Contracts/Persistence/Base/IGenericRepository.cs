using BookManagementSystem.Application.Features.Base;
using BookManagementSystem.Application.Models;
using BookManagementSystem.Domain.Base;

namespace BookManagementSystem.Application.Contracts.Persistence.Base;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> GetAsync(Guid id);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
