using AutoMapper;
using BookManagementSystem.Application.Contracts.Logging;
using BookManagementSystem.Application.Contracts.UnitOfWork;
using BookManagementSystem.Application.Features.Base;

namespace BookManagementSystem.Application.Features.Author.Queries.GetAuthors;

public class GetAuthorsDropdownHandler : BaseQueryHandler<GetAuthorsDropdownQuery, List<AuthorDropdownDTO>>
{
    public GetAuthorsDropdownHandler(IMapper mapper, IApplicationUnitOfWorkCache cache, IApplicationUnitOfWorkRepository repository, IAppLogger<BaseQueryHandler<GetAuthorsDropdownQuery, List<AuthorDropdownDTO>>> logger) : base(mapper, cache, repository, logger)
    {
    }

    protected override async Task<List<AuthorDropdownDTO>> HandleCore(GetAuthorsDropdownQuery request, CancellationToken cancellationToken)
    {
        const string cacheKey = "GetAuthors";
        var authors = await _cache.AuthorCacheService.GetOrSet(
            cacheKey,
            () => Task.Run(async () => (await _repository.Author.GetAllAsync()).ToList()).Result,
            TimeSpan.FromMinutes(1)
            );

        _logger.LogInformation("Authors successfully retrived. Method : {0}", this.ToString());

        return _mapper.Map<List<AuthorDropdownDTO>>(authors);
    }
    public override string ToString()
    {
        return "Get authors query";
    }
}

