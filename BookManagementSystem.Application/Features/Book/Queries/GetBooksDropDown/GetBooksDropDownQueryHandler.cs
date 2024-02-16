using AutoMapper;
using BookManagementSystem.Application.Contracts.Logging;
using BookManagementSystem.Application.Features.Base;
using BookManagementSystem.Application.Models;
using BookManagementSystem.Application.UnitOfWork;

namespace BookManagementSystem.Application.Features.Book.Queries.GetBooksDropDown;

public class GetBooksDropDownQueryHandler : BaseRequestHandler<GetBooksDropDownQuery, List<BookDropDownDTO>>
{
    public GetBooksDropDownQueryHandler(IMapper mapper, IApplicationUnitOfWorkCache cache, IApplicationUnitOfWorkRepository repository, IAppLogger<BaseRequestHandler<GetBooksDropDownQuery, List<BookDropDownDTO>>> logger) : base(mapper, cache, repository, logger)
    {
    }

    protected override async Task<List<BookDropDownDTO>> HandleCore(GetBooksDropDownQuery request, CancellationToken cancellationToken)
    {

        var books = await _cache.BookCacheService.GetOrSet(
         "GetBooks",
         () => Task.Run(async () => (await _repository.Books.GetAllAsync()).OrderBy(x => x.Title).ToList()).Result,
         TimeSpan.FromMinutes(1)
         );

        return _mapper.Map<List<BookDropDownDTO>>(books);

    }
}
