using AutoMapper;
using BookManagementSystem.Application.Features.Author.Queries.GetAuthor;
using BookManagementSystem.Application.Features.Author.Queries.GetAuthors;
using BookManagementSystem.Application.Models;
using BookManagementSystem.Domain;

namespace BookManagementSystem.Application.MappingProfiles;

public class AuthorMappingProfile : Profile
{
    public AuthorMappingProfile()
    {
        CreateMap<Author, AuthorDropdownDTO>().ReverseMap();
        CreateMap<Author, AuthorDetailsDTO>().ReverseMap();
        CreateMap<Author, AuthorPagedListDTO>().ReverseMap();

    }
}
