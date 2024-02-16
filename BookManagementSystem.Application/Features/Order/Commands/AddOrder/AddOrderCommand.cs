using MediatR;

namespace BookManagementSystem.Application.Features.Order.Commands.AddOrder;
public class AddOrderCommand : IRequest<Guid>
{
    public Guid AuthorID { get; set; }
    public ICollection<AddOrderItemDTO> Items { get; set; } = new List<AddOrderItemDTO>();

}



