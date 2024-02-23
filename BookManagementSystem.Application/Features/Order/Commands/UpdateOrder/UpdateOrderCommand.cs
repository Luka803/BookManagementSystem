using AutoMapper;
using BookManagementSystem.Application.Contracts.Logging;
using BookManagementSystem.Application.Features.Base;
using BookManagementSystem.Application.Features.Order.Commands.AddOrder;
using BookManagementSystem.Application.Models;
using BookManagementSystem.Application.UnitOfWork;
using BookManagementSystem.Domain.Enums;
using MediatR;
using MediatR.Wrappers;

namespace BookManagementSystem.Application.Features.Order.Commands.UpdateOrder;

public class UpdateOrderCommand : BaseDTO, IRequest<Guid>
{
    public Guid UserID { get; set; }
    public decimal TotalPrice => 0;
    public int TotalCount => 0;
    public ICollection<UpdateOrderItemDTO> Items { get; set; } = new List<UpdateOrderItemDTO>();
}

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
