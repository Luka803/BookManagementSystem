using AutoMapper;
using BookManagementSystem.Application.Features.Order.Commands.AddOrder;

namespace BookManagementSystem.Application.MappingProfiles;

public class OrderItemMappingProfile : Profile
{
    public OrderItemMappingProfile()
    {
        CreateMap<MyDomain.OrderItem, AddOrderItemDTO>().ReverseMap();
    }
}
