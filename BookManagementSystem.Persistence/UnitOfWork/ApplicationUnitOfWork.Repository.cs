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

    public IOrderRepository Order => throw new NotImplementedException();

    public IOrderItemRepository OrderItem => throw new NotImplementedException();


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
