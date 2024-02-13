using BookManagementSystem.Domain.Base;
using BookManagementSystem.Domain.Enums;

namespace BookManagementSystem.Domain;

public class Order : BaseEntity
{
    public Guid UserID { get; set; }

    public virtual User User { get; set; } = null!;

    public decimal TotalPrice { get; set; }

    public int TotalCount { get; set; }

    public OrderStatus Status { get; set; } = OrderStatus.Created;

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
