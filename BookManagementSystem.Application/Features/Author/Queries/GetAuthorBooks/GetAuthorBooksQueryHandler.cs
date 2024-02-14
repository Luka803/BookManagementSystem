using AutoMapper;
using BookManagementSystem.Application.Contracts.Logging;
using BookManagementSystem.Application.Contracts.UnitOfWork;
using BookManagementSystem.Application.Exceptions;
using BookManagementSystem.Application.Features.Base;
using BookManagementSystem.Application.Models;
using BookManagementSystem.Domain;

namespace BookManagementSystem.Application.Features.Author.Queries.GetAuthorBooks
{
    public class GetAuthorBooksQueryHandler : BaseRequestHandler<GetAuthorBooksQuery, PagedListDTO<AuthorBooksDTO>>
    {
        public GetAuthorBooksQueryHandler(IMapper mapper, IApplicationUnitOfWorkCache cache, IApplicationUnitOfWorkRepository repository, IAppLogger<BaseRequestHandler<GetAuthorBooksQuery, PagedListDTO<AuthorBooksDTO>>> logger) : base(mapper, cache, repository, logger)
        {
        }

        protected async override Task<PagedListDTO<AuthorBooksDTO>> HandleCore(GetAuthorBooksQuery request, CancellationToken cancellationToken)
        {
            var pagedList = new PagedList<AuthorBooksDTO>(new Book());

            var validator = new GetAuthorBooksQueryValidator(_repository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Any())
            {
                throw new FluentValidationException("Validation errors", validationResult);
            }

            pagedList.PageNumber = request.page;

            pagedList.DbItems = await _repository.Author.GetAuthorBooks(request.id);

            pagedList.Items = _mapper.Map<List<AuthorBooksDTO>>(pagedList.DbItemsFiltered);

            return new PagedListDTO<AuthorBooksDTO>
            {
                Items = pagedList.Items,
                TotalItems = pagedList.TotalItems,
                PageNumber = pagedList.PageNumber,
            };
        }
    }

}
