using BookManagementSystem.Application.Features.Base;

namespace BookManagementSystem.Application.Models;

public class PagedListDTO<T> where T : BaseDTO
{
    public IReadOnlyList<T> Items { get; set; } = new List<T>();
    public int TotalItems { get; set; }
    public int PageNumber { get; set; }

}
