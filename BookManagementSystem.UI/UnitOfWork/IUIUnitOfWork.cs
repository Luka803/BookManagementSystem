using BookManagementSystem.UI.Contracts;

namespace BookManagementSystem.UI.UnitOfWork;

public interface IUIUnitOfWork
{
    public IAuthorService Author { get; }
}
