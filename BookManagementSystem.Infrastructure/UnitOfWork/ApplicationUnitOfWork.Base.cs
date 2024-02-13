using BookManagementSystem.Application.Contracts.Logging;
using BookManagementSystem.Application.Contracts.UnitOfWork;
using Microsoft.Extensions.Caching.Memory;

namespace BookManagementSystem.Infrastructure.UnitOfWork;

public partial class ApplicationUnitOfWorkCache : IApplicationUnitOfWorkCache
{
    private readonly IMemoryCache _cacheService;
    private readonly IAppLogger<ApplicationUnitOfWorkCache> _logger;

    public ApplicationUnitOfWorkCache(IMemoryCache cacheService, IAppLogger<ApplicationUnitOfWorkCache> appLogger)
    {
        this._cacheService = cacheService;
        this._logger = appLogger;

    }
}
