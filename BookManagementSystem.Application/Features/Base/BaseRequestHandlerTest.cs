using BookManagementSystem.Domain.Base;
using FluentValidation.Results;
using MediatR;

namespace BookManagementSystem.Application.Features.Base;

public abstract class BaseRequestHandlerTest<TRequest, TEntity, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TEntity : BaseEntity
{
    protected TEntity BaseEntity { get; set; }

    public BaseRequestHandlerTest()
    {

    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public abstract Task<TResponse> HandleCore(TRequest request, CancellationToken cancellationToken);
    public abstract Task<ValidationResult> Validate(TRequest request, CancellationToken cancellationToken);


}
