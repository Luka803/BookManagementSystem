using AutoMapper;
using BookManagementSystem.Application.Contracts.Logging;
using BookManagementSystem.Application.Exceptions;
using BookManagementSystem.Application.Features.Base;
using BookManagementSystem.Application.Models;
using BookManagementSystem.Application.UnitOfWork;

namespace BookManagementSystem.Application.Features.Author.Queries.GetAuthorBooksPagedList;

public class GetAuthorBooksPagedListQueryHandler : BaseRequestHandler<GetAuthorBooksPagedListQuery, PagedListDTO<AuthorBooksDTO>>
{
    public GetAuthorBooksPagedListQueryHandler(IMapper mapper, IApplicationUnitOfWorkCache cache, IApplicationUnitOfWorkRepository repository, IAppLogger<BaseRequestHandler<GetAuthorBooksPagedListQuery, PagedListDTO<AuthorBooksDTO>>> logger) : base(mapper, cache, repository, logger)
    {
    }

    protected async override Task<PagedListDTO<AuthorBooksDTO>> HandleCore(GetAuthorBooksPagedListQuery request, CancellationToken cancellationToken)
    {
        var pagedList = new PagedList<AuthorBooksDTO>(new MyDomain.Book());

        var validator = new GetAuthorBooksPagedListQueryValidator(_repository);
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
