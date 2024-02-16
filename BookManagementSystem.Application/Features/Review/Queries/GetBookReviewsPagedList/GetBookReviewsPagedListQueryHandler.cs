using AutoMapper;
using BookManagementSystem.Application.Contracts.Logging;
using BookManagementSystem.Application.Features.Base;
using BookManagementSystem.Application.Models;
using BookManagementSystem.Application.UnitOfWork;

namespace BookManagementSystem.Application.Features.Review.Queries.GetBookReviewsPagedList;

public class GetBookReviewsPagedListQueryHandler : BaseRequestHandler<GetBookReviewsPagedListQuery, PagedListDTO<BookReviewsPagedListDTO>>
{
    public GetBookReviewsPagedListQueryHandler(IMapper mapper, IApplicationUnitOfWorkCache cache, IApplicationUnitOfWorkRepository repository, IAppLogger<BaseRequestHandler<GetBookReviewsPagedListQuery, PagedListDTO<BookReviewsPagedListDTO>>> logger) : base(mapper, cache, repository, logger)
    {
    }

    protected async override Task<PagedListDTO<BookReviewsPagedListDTO>> HandleCore(GetBookReviewsPagedListQuery request, CancellationToken cancellationToken)
    {
        var pagedList = new PagedList<BookReviewsPagedListDTO>(new MyDomain.Review());

        pagedList.PageNumber = request.page;

        pagedList.DbItems = await _cache.ReviewMemoryCacheService.GetOrSet(
            "GetBooks",
            () => Task.Run(async () => (await _repository.Review.GetAllBookReviews(request.Id)).OrderBy(x => x.Book.Title).ToList()).Result,
            TimeSpan.FromMinutes(1)
            );

        pagedList.Items = _mapper.Map<IReadOnlyList<BookReviewsPagedListDTO>>(pagedList.DbItemsFiltered);

        return new PagedListDTO<BookReviewsPagedListDTO>
        {
            Items = pagedList.Items,
            PageNumber = request.page,
            TotalItems = pagedList.TotalItems,
            TotalPages = pagedList.TotalPages
        };
    }
}
