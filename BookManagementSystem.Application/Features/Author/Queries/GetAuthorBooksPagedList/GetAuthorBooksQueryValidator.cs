using BookManagementSystem.Application.UnitOfWork;
using FluentValidation;

namespace BookManagementSystem.Application.Features.Author.Queries.GetAuthorBooksPagedList;

public class GetAuthorBooksPagedListQueryValidator : AbstractValidator<GetAuthorBooksPagedListQuery>
{
    private readonly IApplicationUnitOfWorkRepository applicationUnitOfWork;

    public GetAuthorBooksPagedListQueryValidator(IApplicationUnitOfWorkRepository applicationUnitOfWork)
    {
        this.applicationUnitOfWork = applicationUnitOfWork;

        RuleFor(x => x)
            .MustAsync(AuthorExist)
            .WithMessage("Author does not exist");
    }

    private async Task<bool> AuthorExist(GetAuthorBooksPagedListQuery query, CancellationToken token)
    {
        var author = await applicationUnitOfWork.Author.GetAsync(query.id);
        return author != null;
    }
}
