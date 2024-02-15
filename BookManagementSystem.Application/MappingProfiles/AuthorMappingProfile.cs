using AutoMapper;
using BookManagementSystem.Application.Features.Author.Commands.AddAuthor;
using BookManagementSystem.Application.Features.Author.Commands.UpdateAuthor;
using BookManagementSystem.Application.Features.Author.Queries.GetAuthor;
using BookManagementSystem.Application.Features.Author.Queries.GetAuthors;
using BookManagementSystem.Domain;

namespace BookManagementSystem.Application.MappingProfiles;

public class AuthorMappingProfile : Profile
{
    public AuthorMappingProfile()
    {
        CreateMap<Author, AuthorDropdownDTO>().ReverseMap();
        CreateMap<Author, AuthorDetailsDTO>().ReverseMap();
        CreateMap<Author, AuthorPagedListDTO>().ReverseMap();
        CreateMap<Author, AddAuthorCommand>().ReverseMap();

        CreateMap<UpdateAuthorCommand, Author>()
            .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
            .ReverseMap();


    }
}
