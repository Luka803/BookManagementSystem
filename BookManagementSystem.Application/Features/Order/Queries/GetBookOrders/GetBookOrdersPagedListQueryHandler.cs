using AutoMapper;
using BookManagementSystem.Application.Contracts.Logging;
using BookManagementSystem.Application.Features.Base;
using BookManagementSystem.Application.Models;
using BookManagementSystem.Application.UnitOfWork;

namespace BookManagementSystem.Application.Features.Order.Queries.GetBookOrders;

public class GetBookOrdersPagedListQueryHandler : BaseRequestHandler<GetBookOrdersPagedListQuery, PagedListDTO<BookOrderDTO>>
{
    public GetBookOrdersPagedListQueryHandler(IMapper mapper, IApplicationUnitOfWorkCache cache, IApplicationUnitOfWorkRepository repository, IAppLogger<BaseRequestHandler<GetBookOrdersPagedListQuery, PagedListDTO<BookOrderDTO>>> logger) : base(mapper, cache, repository, logger)
    {
    }

    protected override async Task<PagedListDTO<BookOrderDTO>> HandleCore(GetBookOrdersPagedListQuery request, CancellationToken cancellationToken)
    {
        var pagedList = new PagedList<BookOrderDTO>(new MyDomain.OrderItem());

        pagedList.PageNumber = request.page;

        pagedList.DbItems = await _cache.OrderItemCacheService.GetOrSet(
            "GetBookOrders",
            () => Task.Run(async () => (await _repository.OrderItem.GetBookOrders(request.bookID))).Result,
            TimeSpan.FromMinutes(1)
            );

        pagedList.Items = _mapper.Map<IReadOnlyList<BookOrderDTO>>(pagedList.DbItemsFiltered);

        return new PagedListDTO<BookOrderDTO>
        {
            Items = pagedList.Items,
            PageNumber = request.page,
            TotalItems = pagedList.TotalItems,
            TotalPages = pagedList.TotalPages
        };
    }
}