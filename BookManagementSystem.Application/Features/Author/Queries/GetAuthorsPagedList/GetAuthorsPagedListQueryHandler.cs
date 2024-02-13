using AutoMapper;
using BookManagementSystem.Application.Contracts.Logging;
using BookManagementSystem.Application.Contracts.UnitOfWork;
using BookManagementSystem.Application.Features.Author.Queries.GetAuthors;
using BookManagementSystem.Application.Features.Base;
using BookManagementSystem.Application.Models;
using MyDomain = BookManagementSystem.Domain;

namespace BookManagementSystem.Application.Features.Author.Queries.GetAuthorsPagedList;

public class GetAuthorsPagedListQueryHandler : BaseRequestHandler<GetAuthorsPagedListQuery, PagedListDTO<AuthorPagedListDTO>>
{
    public GetAuthorsPagedListQueryHandler(IMapper mapper, IApplicationUnitOfWorkCache cache, IApplicationUnitOfWorkRepository repository, IAppLogger<BaseRequestHandler<GetAuthorsPagedListQuery, PagedListDTO<AuthorPagedListDTO>>> logger) : base(mapper, cache, repository, logger)
    {
    }

    protected async override Task<PagedListDTO<AuthorPagedListDTO>> HandleCore(GetAuthorsPagedListQuery request, CancellationToken cancellationToken)
    {
        var pagedList = new PagedList<AuthorPagedListDTO>(new MyDomain.Author());

        pagedList.PageNumber = request.page;

        pagedList.DbItems = await _cache.AuthorCacheService.GetOrSet(
            "GetAuthors",
            () => Task.Run(async () => (await _repository.Author.GetAllAsync()).OrderBy(x => x.AuthorName).ToList()).Result,
            TimeSpan.FromMinutes(1)
            );


        pagedList.Items = _mapper.Map<IReadOnlyList<AuthorPagedListDTO>>(pagedList.DbItemsFiltered);

        return new PagedListDTO<AuthorPagedListDTO>
        {
            Items = pagedList.Items,
            TotalItems = pagedList.TotalItems,
            PageNumber = pagedList.PageNumber,
        };
    }
}
