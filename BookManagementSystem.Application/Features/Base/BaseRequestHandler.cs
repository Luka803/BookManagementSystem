using AutoMapper;
using BookManagementSystem.Application.Contracts.Logging;
using BookManagementSystem.Application.UnitOfWork;
using MediatR;

namespace BookManagementSystem.Application.Features.Base;

public abstract class BaseRequestHandler<TRequest, TResult> : IRequestHandler<TRequest, TResult>
    where TRequest : IRequest<TResult>
{

    protected readonly IMapper _mapper;
    protected readonly IApplicationUnitOfWorkCache _cache;
    protected readonly IApplicationUnitOfWorkRepository _repository;
    protected readonly IAppLogger<BaseRequestHandler<TRequest, TResult>> _logger;

    protected BaseRequestHandler(IMapper mapper, IApplicationUnitOfWorkCache cache, IApplicationUnitOfWorkRepository repository, IAppLogger<BaseRequestHandler<TRequest, TResult>> logger)
    {
        _mapper = mapper;
        _repository = repository;
        _cache = cache;
        _logger = logger;

    }

    public async Task<TResult> Handle(TRequest request, CancellationToken cancellationToken)
    {
        return await HandleCore(request, cancellationToken);
    }
    protected abstract Task<TResult> HandleCore(TRequest request, CancellationToken cancellationToken);



}
