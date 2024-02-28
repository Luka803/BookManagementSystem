using AutoMapper;
using BookManagementSystem.UI.Models;
using BookManagementSystem.UI.Services.Base;

namespace BookManagementSystem.UI.MappingProfile;

public class VMMappingProfile : Profile
{

    public VMMappingProfile()
    {

        CreateMap<AuthorPagedListDTO, AuthorPagedListVM>().ReverseMap();

        CreateMap<AuthorBooksDTO, AuthorBookVM>().ReverseMap();

    }
}
