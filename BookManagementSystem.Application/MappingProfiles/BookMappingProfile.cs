using AutoMapper;
using BookManagementSystem.Application.Features.Author.Queries.GetAuthorBooksPagedList;
using BookManagementSystem.Application.Features.Book.Queries.GetBook;
using BookManagementSystem.Application.Features.Book.Queries.GetBooksDropDown;
using BookManagementSystem.Application.Features.Book.Queries.GetBooksPagedList;
using BookManagementSystem.Domain;

namespace BookManagementSystem.Application.MappingProfiles;

public class BookMappingProfile : Profile
{
    public BookMappingProfile()
    {
        CreateMap<Book, AuthorBooksDTO>().ReverseMap();
        CreateMap<BookWithDetailsDTO, Book>().ReverseMap();

        CreateMap<BookPagedListDTO, Book>().ReverseMap();
        CreateMap<BookDropDownDTO, Book>().ReverseMap();
    }
}
