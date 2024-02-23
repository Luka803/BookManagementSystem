using AutoMapper;
using BookManagementSystem.Application.Contracts.Logging;
using BookManagementSystem.Application.Features.Base;
using BookManagementSystem.Application.UnitOfWork;

namespace BookManagementSystem.Application.Features.Order.Commands.UpdateOrder;

public class UpdateOrderCommandHandler : BaseRequestHandler<UpdateOrderCommand, Guid>
{
    public UpdateOrderCommandHandler(IMapper mapper, IApplicationUnitOfWorkCache cache, IApplicationUnitOfWorkRepository repository, IAppLogger<BaseRequestHandler<UpdateOrderCommand, Guid>> logger) : base(mapper, cache, repository, logger)
    {
    }

    protected async override Task<Guid> HandleCore(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var orderToUpdate = await _repository.Order.GetAsync(request.ID);

        if (orderToUpdate == null)
            throw new NotFoundException(nameof(Order), request.ID);

        _mapper.Map(request, orderToUpdate);

        await _repository.Order.UpdateAsync(orderToUpdate);

        return request.ID;
    }
}
