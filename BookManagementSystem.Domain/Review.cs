using BookManagementSystem.Domain.Base;

namespace BookManagementSystem.Domain;

public class Review : BaseEntity
{
    public Guid BookID { get; set; }
    public virtual Book Book { get; set; } = null!;
    public Guid UserID { get; set; }
    public virtual User User { get; set; } = null!;
    public decimal Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
}
