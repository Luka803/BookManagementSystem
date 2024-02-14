using AutoMapper;
using BookManagementSystem.Application.Features.Author.Queries.GetAuthorBooks;
using BookManagementSystem.Domain;

namespace BookManagementSystem.Application.MappingProfiles;

public class BookMappingProfile : Profile
{
    public BookMappingProfile()
    {
        CreateMap<Book, AuthorBooksDTO>().ReverseMap();
    }
}
