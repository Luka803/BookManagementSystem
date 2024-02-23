using AutoMapper;
using BookManagementSystem.Application.Features.Order.Commands.AddOrder;
using BookManagementSystem.Application.Features.Order.Queries.GetBookOrders;

namespace BookManagementSystem.Application.MappingProfiles;

public class OrderItemMappingProfile : Profile
{
    public OrderItemMappingProfile()
    {
        CreateMap<MyDomain.OrderItem, AddOrderItemDTO>().ReverseMap();

        CreateMap<MyDomain.OrderItem, BookOrderDTO>()
                         .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Order.Status))
                         .ReverseMap();
    }
}
