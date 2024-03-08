using BookManagementSystem.UI.Contracts;

namespace BookManagementSystem.UI.UnitOfWork;

public interface IUnitOfWork
{
    public IAuthorService Author { get; }
    public IBookService Book { get; }
    public IOrderService Order { get; }
}
