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

    protected IReviewRepository? _Review;
    public IReviewRepository Review
    {
        get
        {
            return _Review ?? (_Review = new ReviewRepository(dbContext));
        }
    }

    protected IUserRepository? _User;
    public IUserRepository User
    {
        get
        {
            return _User ?? (_User = new UserRepository(dbContext));
        }
    }

}
