using AutoMapper;
using BookManagementSystem.Application.Contracts.Logging;
using BookManagementSystem.Application.Features.Base;
using BookManagementSystem.Application.Models;
using BookManagementSystem.Application.UnitOfWork;

namespace BookManagementSystem.Application.Features.Review.Queries.GetReviewsPagedList;

public class GetReviewsPagedListQueryHandler : BaseRequestHandler<GetReviewsPagedListQuery, PagedListDTO<GetReviewsPagedListDTO>>
{
    public GetReviewsPagedListQueryHandler(IMapper mapper, IApplicationUnitOfWorkCache cache, IApplicationUnitOfWorkRepository repository, IAppLogger<BaseRequestHandler<GetReviewsPagedListQuery, PagedListDTO<GetReviewsPagedListDTO>>> logger) : base(mapper, cache, repository, logger)
    {
    }

    protected async override Task<PagedListDTO<GetReviewsPagedListDTO>> HandleCore(GetReviewsPagedListQuery request, CancellationToken cancellationToken)
    {
        var pagedList = new PagedList<GetReviewsPagedListDTO>(new MyDomain.Review());

        pagedList.PageNumber = request.page;

        pagedList.DbItems = await _cache.ReviewMemoryCacheService.GetOrSet(
            "GetReviews",
            () => Task.Run(async () => (await _repository.Review.GetAllAsync()).ToList()).Result,
            TimeSpan.FromMinutes(1)
            );

        pagedList.Items = _mapper.Map<IReadOnlyList<GetReviewsPagedListDTO>>(pagedList.DbItemsFiltered);

        return new PagedListDTO<GetReviewsPagedListDTO>
        {
            Items = pagedList.Items,
            PageNumber = request.page,
            TotalItems = pagedList.TotalItems,
            TotalPages = pagedList.TotalPages
        };
    }
}
