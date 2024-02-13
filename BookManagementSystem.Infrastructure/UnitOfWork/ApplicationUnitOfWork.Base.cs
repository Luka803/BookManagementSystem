using BookManagementSystem.Application.Contracts.UnitOfWork;
using Microsoft.Extensions.Caching.Memory;

namespace BookManagementSystem.Infrastructure.UnitOfWork;

public partial class ApplicationUnitOfWorkCache : IApplicationUnitOfWorkCache
{
    private readonly IMemoryCache _cacheService;

    public ApplicationUnitOfWorkCache(IMemoryCache cacheService)
    {
        this._cacheService = cacheService;
    }
}
