using BookManagementSystem.Application.Contracts.Caching;
using BookManagementSystem.Application.Contracts.UnitOfWork;
using BookManagementSystem.Infrastructure.Caching;

namespace BookManagementSystem.Infrastructure.UnitOfWork;

public partial class ApplicationUnitOfWorkCache : IApplicationUnitOfWorkCache
{
    protected IAuthorMemoryCacheService? _authorMemoryCacheService;
    public IAuthorMemoryCacheService AuthorCacheService
    {
        get
        {
            return _authorMemoryCacheService ?? (_authorMemoryCacheService = new AuthorCacheService(_cacheService));
        }
    }
    public IBookMemoryCacheService BookCacheService { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public IOrderMemoryCacheService OrderCacheService { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public IOrderItemMemoryCacheService OrderItemCacheService { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public IReviewMemoryCacheService ReviewMemoryCacheService { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public IUserMemoryCacheService UserMemoryCacheService { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
