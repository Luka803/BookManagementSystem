using BookManagementSystem.Application.Features.Order.Commands.AddOrder;
using BookManagementSystem.Application.UnitOfWork;
using FluentValidation;


namespace BookManagementSystem.Application.Features.Order.Commands.UpdateOrder;
public class UpdateOrderCommandValidator : AbstractValidator<AddOrderCommand>
{
    private readonly IApplicationUnitOfWorkRepository _repository;
    public UpdateOrderCommandValidator(IApplicationUnitOfWorkRepository repository)
    {
        this._repository = repository;

        RuleFor(x => x)
            .Must(ListNotEmpty)
            .WithMessage("Order has to have at least one order item");

        RuleFor(x => x.UserID)
            .MustAsync(UserExist)
            .WithMessage("User with this ID does not exist");

        RuleFor(x => x.Items)
            .MustAsync(BooksExist)
            .WithMessage("Some of the books with this ID are not exist");

        RuleFor(x => x.Items.Count)
            .NotEmpty()
            .GreaterThan(0);
    }

    private async Task<bool> BooksExist(ICollection<AddOrderItemDTO> collection, CancellationToken token)
    {
        foreach (var item in collection)
        {
            var book = await _repository.Books.GetAsync(item.BookID);

            if (book == null)
                return true;
        }
        return false;
    }

    private async Task<bool> UserExist(Guid guid, CancellationToken token)
    {
        var user = await _repository.User.GetAsync(guid);
        return user != null;
    }

    private bool ListNotEmpty(AddOrderCommand command)
    {
        return command.Items.Any() == false;
    }
}
