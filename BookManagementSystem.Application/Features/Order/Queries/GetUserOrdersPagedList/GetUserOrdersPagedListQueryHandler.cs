using AutoMapper;
using BookManagementSystem.Application.Contracts.Logging;
using BookManagementSystem.Application.Features.Base;
using BookManagementSystem.Application.Models;
using BookManagementSystem.Application.UnitOfWork;

namespace BookManagementSystem.Application.Features.Order.Queries.GetUserOrdersPagedList;

public class GetUserOrdersPagedListQueryHandler : BaseRequestHandler<GetUserOrdersPagedListQuery, PagedListDTO<UserOrdersDTO>>
{
    public GetUserOrdersPagedListQueryHandler(IMapper mapper, IApplicationUnitOfWorkCache cache, IApplicationUnitOfWorkRepository repository, IAppLogger<BaseRequestHandler<GetUserOrdersPagedListQuery, PagedListDTO<UserOrdersDTO>>> logger) : base(mapper, cache, repository, logger)
    {
    }

    protected override async Task<PagedListDTO<UserOrdersDTO>> HandleCore(GetUserOrdersPagedListQuery request, CancellationToken cancellationToken)
    {
        var pagedList = new PagedList<UserOrdersDTO>(new MyDomain.Order());

        pagedList.PageNumber = request.page;

        pagedList.DbItems = await _repository.Order.GetUserOrders(request.userId);

        pagedList.Items = _mapper.Map<IReadOnlyList<UserOrdersDTO>>(pagedList.DbItemsFiltered);

        return new PagedListDTO<UserOrdersDTO>
        {
            Items = pagedList.Items,
            PageNumber = request.page,
            TotalItems = pagedList.TotalItems,
            TotalPages = pagedList.TotalPages
        };

    }
}
