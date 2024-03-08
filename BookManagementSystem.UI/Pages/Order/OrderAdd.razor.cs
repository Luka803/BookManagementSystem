using BookManagementSystem.UI.Models.Book;
using BookManagementSystem.UI.Models.Order;

namespace BookManagementSystem.UI.Pages.Order
{
    public partial class OrderAdd
    {
        public OrderAddVM Order { get; set; } = new OrderAddVM();
        public OrderItemAddVM OrderItem { get; set; } = new OrderItemAddVM();
        public ICollection<OrderItemAddVM> Items { get; set; } = new List<OrderItemAddVM>();
        public IReadOnlyList<BookPagedListVM> Books { get; set; } = null!;
        public string[]? Routes { get; set; }
        public int ItemNumber { get; set; } = 1;

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            Books = await unitOfWork.Book.GetBooks(new BookIndexVM());
        }

        private async void Add()
        {
            await unitOfWork.Order.AddOrder(Order);
        }

        private void AddOrderItem()
        {
            OrderItem.ItemNumber = ItemNumber++;
            Items.Add(OrderItem);
            OrderItem = new OrderItemAddVM();
        }

    }
}