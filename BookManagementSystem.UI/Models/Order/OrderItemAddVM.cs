namespace BookManagementSystem.UI.Models.Order;
public class OrderItemAddVM
{
    public Guid BookID { get; set; }

    public decimal Price = 0;

    public int ItemNumber { get; set; }
    public int Count { get; set; }
}
