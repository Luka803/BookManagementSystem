using AutoMapper;
using BookManagementSystem.UI.Models.Author;
using BookManagementSystem.UI.Services.Base;

namespace BookManagementSystem.UI.MappingProfile;

public class VMMappingProfile : Profile
{

    public VMMappingProfile()
    {

        CreateMap<AuthorPagedListDTO, AuthorPagedListVM>().ReverseMap();

        CreateMap<AuthorBooksDTO, AuthorBookVM>().ReverseMap();

        CreateMap<AuthorDetailsVM, AuthorDetailsDTO>().ReverseMap();

        CreateMap<AuthorEditVM, AuthorDetailsDTO>().ReverseMap();

        CreateMap<AuthorEditVM, UpdateAuthorCommand>().ReverseMap();

    }
}
