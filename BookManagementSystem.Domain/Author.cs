using BookManagementSystem.Domain.Base;

namespace BookManagementSystem.Domain;

public class Author : BaseEntity
{
    public string AuthorName { get; set; } = null!;

    public string Biography { get; set; } = string.Empty;

    public int BirthYear { get; set; }

}
