using AutoMapper;
using BookManagementSystem.Application.Contracts.Logging;
using BookManagementSystem.Application.Features.Base;
using BookManagementSystem.Application.Models;
using BookManagementSystem.Application.UnitOfWork;

namespace BookManagementSystem.Application.Features.Book.Queries.GetBooksPagedList;

public class GetBooksPagedListQueryHandler : BaseRequestHandler<GetBooksPagedListQuery, PagedListDTO<BookPagedListDTO>>
{
    public GetBooksPagedListQueryHandler(IMapper mapper, IApplicationUnitOfWorkCache cache, IApplicationUnitOfWorkRepository repository, IAppLogger<BaseRequestHandler<GetBooksPagedListQuery, PagedListDTO<BookPagedListDTO>>> logger) : base(mapper, cache, repository, logger)
    {
    }

    protected async override Task<PagedListDTO<BookPagedListDTO>> HandleCore(GetBooksPagedListQuery request, CancellationToken cancellationToken)
    {
        var pagedList = new PagedList<BookPagedListDTO>(new MyDomain.Book());

        pagedList.PageNumber = request.page;

        pagedList.DbItems = await _cache.BookCacheService.GetOrSet(
            "GetBooks",
            () => Task.Run(async () => (await _repository.Books.GetBooksWithDetails()).OrderBy(x => x.Title).ToList()).Result,
            TimeSpan.FromMinutes(1)
            );

        pagedList.Items = _mapper.Map<IReadOnlyList<BookPagedListDTO>>(pagedList.DbItemsFiltered);

        return new PagedListDTO<BookPagedListDTO>
        {
            Items = pagedList.Items,
            PageNumber = request.page,
            TotalItems = pagedList.TotalItems,
            TotalPages = pagedList.TotalPages
        };
    }
}