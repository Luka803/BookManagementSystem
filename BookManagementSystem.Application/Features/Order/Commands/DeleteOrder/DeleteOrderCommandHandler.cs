using AutoMapper;
using BookManagementSystem.Application.Contracts.Logging;
using BookManagementSystem.Application.Features.Base;
using BookManagementSystem.Application.UnitOfWork;
using MediatR;

namespace BookManagementSystem.Application.Features.Order.Commands.DeleteOrder;

public class DeleteOrderCommandHandler : BaseRequestHandler<DeleteOrderCommand, Unit>
{
    public DeleteOrderCommandHandler(IMapper mapper, IApplicationUnitOfWorkCache cache, IApplicationUnitOfWorkRepository repository, IAppLogger<BaseRequestHandler<DeleteOrderCommand, Unit>> logger) : base(mapper, cache, repository, logger)
    {
    }

    protected override async Task<Unit> HandleCore(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var orderWithItems = await _repository.Order.GetOrderWithItems(request.id);

        await _repository.Order.DeleteAsync(orderWithItems);

        return Unit.Value;

    }
}