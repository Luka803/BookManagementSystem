namespace BookManagementSystem.UI.Models.Order;
public enum OrderStatus
{
    Created = 1,
    Verified = 2,
    Shipped = 3,
    Canceled = 10
}
public class OrderAddVM
{
    public Guid UserID { get; set; }
    public decimal TotalPrice => 0;
    public int TotalCount => 0;

    public OrderStatus Status = OrderStatus.Created;
    public ICollection<OrderItemAddVM> Items { get; set; } = new List<OrderItemAddVM>();
}
