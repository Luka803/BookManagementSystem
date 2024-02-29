using AutoMapper;
using BookManagementSystem.UI.Models.Author;
using BookManagementSystem.UI.Models.Book;
using BookManagementSystem.UI.Services.Base;

namespace BookManagementSystem.UI.MappingProfile;

public class VMMappingProfile : Profile
{

    public VMMappingProfile()
    {
        #region Author
        CreateMap<AuthorPagedListDTO, AuthorPagedListVM>().ReverseMap();
        CreateMap<AuthorBooksDTO, AuthorBookVM>().ReverseMap();
        CreateMap<AuthorDetailsVM, AuthorDetailsDTO>().ReverseMap();
        CreateMap<AuthorEditVM, AuthorDetailsDTO>().ReverseMap();
        CreateMap<AuthorEditVM, UpdateAuthorCommand>().ReverseMap();
        CreateMap<AuthorAddVM, AddAuthorCommand>().ReverseMap();
        CreateMap<AuthorIndexVM, GetAuthorsPagedListQuery>().ReverseMap();
        CreateMap<GetAuthorsPagedListQuery, AuthorPagedListVM>().ReverseMap();
        #endregion

        #region Book

        CreateMap<BookPagedListDTO, BookPagedListVM>().ReverseMap();
        CreateMap<BookAddVM, AddBookCommand>().ReverseMap();

        #endregion

    }
}
