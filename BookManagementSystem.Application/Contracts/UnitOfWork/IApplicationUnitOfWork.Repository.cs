using BookManagementSystem.Application.Contracts.Persistence;

namespace BookManagementSystem.Application.Contracts.UnitOfWork;

public interface IApplicationUnitOfWorkRepository
{
    //Repo
    public IUserRepository User { get; }
    public IBookRepository Books { get; }
    public IOrderRepository Order { get; }
    public IOrderItemRepository OrderItem { get; }
    public IAuthorRepository Author { get; }
    public IReviewRepository Review { get; }
}
