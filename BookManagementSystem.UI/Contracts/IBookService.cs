using BookManagementSystem.UI.Models.Book;

namespace BookManagementSystem.UI.Contracts;

public interface IBookService
{
    Task<IReadOnlyList<BookPagedListVM>> GetBooks(BookIndexVM book);
    Task<int> GetBookTotalItems();
    Task<int> GetBookTotalPages();
    Task<Guid> AddBook(BookAddVM book);
}
