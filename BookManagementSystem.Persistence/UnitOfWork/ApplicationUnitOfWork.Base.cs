using BookManagementSystem.Application.UnitOfWork;
using BookManagementSystem.Persistence.DataBaseContext;
using System.Runtime.InteropServices;

namespace BookManagementSystem.Persistence.UnitOfWork;

public partial class ApplicationUnitOfWork : IApplicationUnitOfWorkRepository
{
    private readonly BookManagementSystemDbContext dbContext;
    public ApplicationUnitOfWork(BookManagementSystemDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public void Dispose()
    {
        dbContext.Dispose();
    }
    public async Task SaveChanges()
    {
        await dbContext.SaveChangesAsync();
    }
}
