using BookManagementSystem.Application.Models;

namespace BookManagementSystem.Application.Features.Book.Queries.GetBooksDropDown;

public class BookDropDownDTO : BaseDTO
{
    public string Title { get; set; } = null!;
}
