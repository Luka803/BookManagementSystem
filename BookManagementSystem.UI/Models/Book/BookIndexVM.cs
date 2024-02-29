using System.ComponentModel.DataAnnotations;
using BookManagementSystem.UI.Models.Base;

namespace BookManagementSystem.UI.Models.Book;

public class BookIndexVM : BaseVM
{
    [Required]
    public int Page { get; set; }
    public string? Title { get; set; }
    public int? PublicationYearStart { get; set; }
    public int? PublicationYearEnd { get; set; }
    public string? AuthorName { get; set; }
    public decimal? PriceStart { get; set; }
    public decimal? PriceEnd { get; set; }

}

