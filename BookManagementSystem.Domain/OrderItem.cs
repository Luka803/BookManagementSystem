using BookManagementSystem.Domain.Base;

namespace BookManagementSystem.Domain;

public class OrderItem : BaseEntity
{
    public Guid OrderID { get; set; }

    public virtual Order Order { get; set; } = null!;

    public int ItemNumber { get; set; }

    public Guid BookID { get; set; }

    public virtual Book Book { get; set; } = null!;

    public int Count { get; set; }

    public decimal Price => Count * Book.Price;

}
