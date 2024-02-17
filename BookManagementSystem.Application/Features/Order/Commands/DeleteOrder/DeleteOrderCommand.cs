using BookManagementSystem.Domain.Enums;
using MediatR;

namespace BookManagementSystem.Application.Features.Order.Commands.DeleteOrder;

public record DeleteOrderCommand(Guid id) : IRequest<Unit>;
