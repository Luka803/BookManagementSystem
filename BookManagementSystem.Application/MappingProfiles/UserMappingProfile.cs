using AutoMapper;
using BookManagementSystem.Application.Features.User.Queries.GetUserDetails;

namespace BookManagementSystem.Application.MappingProfiles;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<MyDomain.User, UserDetailsDTO>().ReverseMap();
    }
}
