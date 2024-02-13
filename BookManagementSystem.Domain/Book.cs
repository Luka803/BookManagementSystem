using BookManagementSystem.Domain.Base;

namespace BookManagementSystem.Domain;

public class Book : BaseEntity
{
    public string Title { get; set; } = null!;

    public Guid AuthorID { get; set; }

    public virtual Author Author { get; set; } = null!;

    public int ISBN { get; set; }

    public decimal Price { get; set; }

    public int PublicationYear { get; set; }

    public ICollection<Review> Reviews { get; set; } = new List<Review>();


}
