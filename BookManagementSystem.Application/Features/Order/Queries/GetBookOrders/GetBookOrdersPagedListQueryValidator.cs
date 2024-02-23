using BookManagementSystem.Application.UnitOfWork;
using FluentValidation;

namespace BookManagementSystem.Application.Features.Order.Queries.GetBookOrders;

public class GetBookOrdersPagedListQueryValidator : AbstractValidator<GetBookOrdersPagedListQuery>
{
    private readonly IApplicationUnitOfWorkRepository _repository;
    public GetBookOrdersPagedListQueryValidator(IApplicationUnitOfWorkRepository repository)
    {
        this._repository = repository;

        RuleFor(x => x)
            .MustAsync(BookExist)
            .WithMessage("Book with this ID does not exist");
    }

    private async Task<bool> BookExist(GetBookOrdersPagedListQuery query, CancellationToken token)
    {
        var book = await _repository.Books.GetAsync(query.bookID);
        return book != null;
    }
}
