using AutoMapper;
using BookManagementSystem.Application.Contracts.Logging;
using BookManagementSystem.Application.Features.Base;
using BookManagementSystem.Application.UnitOfWork;
using System.Runtime.InteropServices;

namespace BookManagementSystem.Application.Features.Order.Commands.AddOrder;

public class AddOrderCommandHandler : BaseRequestHandler<AddOrderCommand, Guid>
{
    public AddOrderCommandHandler(IMapper mapper, IApplicationUnitOfWorkCache cache, IApplicationUnitOfWorkRepository repository, IAppLogger<BaseRequestHandler<AddOrderCommand, Guid>> logger) : base(mapper, cache, repository, logger)
    {
    }

    protected override async Task<Guid> HandleCore(AddOrderCommand request, CancellationToken cancellationToken)
    {
        int itemNumber = 1;
        int totalCount = 0;
        decimal totalPrice = 0;

        var orderToAdd = _mapper.Map<MyDomain.Order>(request);
        await _repository.Order.CreateAsync(orderToAdd);

        foreach (var item in request.Items)
        {
            var book = await _repository.Books.GetAsync(item.BookID);
            item.OrderID = orderToAdd.ID;
            item.ItemNumber = itemNumber++;
            item.Price = item.Count * book.Price;

            totalCount += item.Count;
            totalPrice += item.Count * book.Price;

            var orderItemToAdd = _mapper.Map<MyDomain.OrderItem>(item);

            await _repository.OrderItem.CreateAsync(orderItemToAdd);
        }

        orderToAdd.TotalPrice = totalPrice;
        orderToAdd.TotalCount = totalCount;

        await _repository.Order.UpdateAsync(orderToAdd);

        return orderToAdd.ID;
    }
}



