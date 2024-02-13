using BookManagementSystem.Application.Contracts.UnitOfWork;
using BookManagementSystem.Persistence.DataBaseContext;

namespace BookManagementSystem.Persistence.UnitOfWork;

public partial class ApplicationUnitOfWork : IApplicationUnitOfWorkRepository
{
    private readonly BookManagementSystemDbContext dbContext;
    public ApplicationUnitOfWork(BookManagementSystemDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

}
