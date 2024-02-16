using AutoMapper;
using BookManagementSystem.Application.Contracts.Logging;
using BookManagementSystem.Application.Features.Base;
using BookManagementSystem.Application.UnitOfWork;

namespace BookManagementSystem.Application.Features.Order.Commands.AddOrder;

public class AddOrderCommandHandler : BaseRequestHandler<AddOrderCommand, Guid>
{
    public AddOrderCommandHandler(IMapper mapper, IApplicationUnitOfWorkCache cache, IApplicationUnitOfWorkRepository repository, IAppLogger<BaseRequestHandler<AddOrderCommand, Guid>> logger) : base(mapper, cache, repository, logger)
    {
    }

    protected override async Task<Guid> HandleCore(AddOrderCommand request, CancellationToken cancellationToken)
    {
        var orderToAdd = _mapper.Map<MyDomain.Order>(request);

        await _repository.Order.CreateAsync(orderToAdd);

        var orderItemsToAdd = _mapper.Map<List<MyDomain.OrderItem>>(orderToAdd.OrderItems);

        foreach (var item in orderItemsToAdd)
        {
            item.OrderID = orderToAdd.ID;
            await _repository.OrderItem.CreateAsync(item);
        }

        return orderToAdd.ID;

    }
}



