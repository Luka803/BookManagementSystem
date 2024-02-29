using AutoMapper;
using BookManagementSystem.UI.Contracts;
using BookManagementSystem.UI.Models.Book;
using BookManagementSystem.UI.Services.Base;

namespace BookManagementSystem.UI.Services;

public class BookService : BaseHttpService, IBookService
{
    public BookService(IClient client, IMapper mapper) : base(client, mapper)
    {
    }

    public async Task<Guid> AddBook(BookAddVM book)
    {
        var bookToAdd = _mapper.Map<AddBookCommand>(book);
        return await _client.AddBookAsync(bookToAdd);
    }

    public async Task<IReadOnlyList<BookPagedListVM>> GetBooks(BookIndexVM book)
    {
        var books = await _client.BookAllAsync(book.Page);
        return _mapper.Map<IReadOnlyList<BookPagedListVM>>(books);
    }

    public async Task<int> GetBookTotalItems()
    {
        return await _client.GetBookTotalItemsAsync();
    }

    public async Task<int> GetBookTotalPages()
    {
        return await _client.GetBookTotalPagesAsync();
    }
}
