using AutoMapper;
using BookManagementSystem.Application.Features.Order.Commands.AddOrder;

namespace BookManagementSystem.Application.MappingProfiles;

public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        CreateMap<MyDomain.Order, AddOrderCommand>().ReverseMap();
    }
}
