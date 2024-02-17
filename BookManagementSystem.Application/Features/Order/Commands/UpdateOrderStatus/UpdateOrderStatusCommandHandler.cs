using AutoMapper;
using BookManagementSystem.Application.Contracts.Logging;
using BookManagementSystem.Application.Features.Base;
using BookManagementSystem.Application.UnitOfWork;

namespace BookManagementSystem.Application.Features.Order.Commands.UpdateOrderStatus;

public class UpdateOrderStatusCommandHandler : BaseRequestHandler<UpdateOrderStatusCommand, Guid>
{
    public UpdateOrderStatusCommandHandler(IMapper mapper, IApplicationUnitOfWorkCache cache, IApplicationUnitOfWorkRepository repository, IAppLogger<BaseRequestHandler<UpdateOrderStatusCommand, Guid>> logger) : base(mapper, cache, repository, logger)
    {
    }

    protected override async Task<Guid> HandleCore(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
    {
        var orderToUpdateStatus = await _repository.Order.GetAsync(request.OrderID);

        orderToUpdateStatus.Status = request.OrderStatus;

        await _repository.Order.UpdateAsync(orderToUpdateStatus);

        return request.OrderID;

    }
}
