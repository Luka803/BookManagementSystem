using BookManagementSystem.Application.Contracts.UnitOfWork;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Application.Features.Author.Queries.GetAuthorBooks
{
    public class GetAuthorBooksQueryValidator : AbstractValidator<GetAuthorBooksQuery>
    {
        private readonly IApplicationUnitOfWorkRepository applicationUnitOfWork;

        public GetAuthorBooksQueryValidator(IApplicationUnitOfWorkRepository applicationUnitOfWork)
        {
            this.applicationUnitOfWork = applicationUnitOfWork;

            RuleFor(x => x)
                .MustAsync(AuthorExist)
                .WithMessage("Author does not exist");
        }

        private async Task<bool> AuthorExist(GetAuthorBooksQuery query, CancellationToken token)
        {
            var author = await applicationUnitOfWork.Author.GetAsync(query.id);
            return author != null;
        }
    }
}
