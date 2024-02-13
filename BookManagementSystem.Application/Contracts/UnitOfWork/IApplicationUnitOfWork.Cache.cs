using BookManagementSystem.Application.Contracts.Caching;

namespace BookManagementSystem.Application.Contracts.UnitOfWork;

public interface IApplicationUnitOfWorkCache
{
    //Cache
    public IAuthorMemoryCacheService AuthorCacheService { get; }
    public IBookMemoryCacheService BookCacheService { get; }
    public IOrderMemoryCacheService OrderCacheService { get; }
    public IOrderItemMemoryCacheService OrderItemCacheService { get; }
    public IReviewMemoryCacheService ReviewMemoryCacheService { get; }
    public IUserMemoryCacheService UserMemoryCacheService { get; }

}
