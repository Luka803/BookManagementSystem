using BookManagementSystem.UI.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace BookManagementSystem.UI.Models;

public class AuthorPagedListVM : BaseVM
{
    [Display(Name = "Name")]
    public string AuthorName { get; set; } = null!;
    public string Biography { get; set; } = string.Empty;

    [Display(Name = "Year of birth")]
    public int BirthYear { get; set; }
}
