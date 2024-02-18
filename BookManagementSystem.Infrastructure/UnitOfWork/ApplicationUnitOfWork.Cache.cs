﻿using BookManagementSystem.Application.Contracts.Caching;
using BookManagementSystem.Application.UnitOfWork;
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

    protected IBookMemoryCacheService? _Book;
    public IBookMemoryCacheService BookCacheService
    {
        get
        {
            return _Book ?? (_Book = new BookCacheService(_cacheService));
        }
    }

    public IOrderMemoryCacheService OrderCacheService => throw new NotImplementedException();

    public IOrderItemMemoryCacheService OrderItemCacheService => throw new NotImplementedException();

    public IReviewMemoryCacheService ReviewMemoryCacheService => throw new NotImplementedException();

    public IUserMemoryCacheService UserMemoryCacheService => throw new NotImplementedException();

}
