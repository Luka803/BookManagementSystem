using BookManagementSystem.Application.Contracts.Persistence;
using BookManagementSystem.Persistence.Repositories;

namespace BookManagementSystem.Persistence.UnitOfWork;

public partial class ApplicationUnitOfWork
{
    protected IBookRepository? _Books;
    public IBookRepository Books
    {
        get
        {
            return _Books ?? (_Books = new BookRepository(dbContext));
        }
    }

    protected IOrderRepository? _Order;
    public IOrderRepository Order
    {
        get
        {
            return _Order ?? (_Order = new OrderRepository(dbContext));
        }
    }

    protected IOrderItemRepository? _OrderItem;
    public IOrderItemRepository OrderItem
    {
        get
        {
            return _OrderItem ?? (_OrderItem = new OrderItemRepository(dbContext));
        }
    }

    protected IAuthorRepository? _Author;
    public IAuthorRepository Author
    {
        get
        {
            return _Author ?? (_Author = new AuthorRepository(dbContext));
        }
    }

    public IReviewRepository Review => throw new NotImplementedException();
    public IUserRepository User => throw new NotImplementedException();
}
