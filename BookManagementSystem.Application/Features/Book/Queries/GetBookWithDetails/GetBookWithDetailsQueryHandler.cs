using AutoMapper;
using BookManagementSystem.Application.Contracts.Logging;
using BookManagementSystem.Application.Exceptions;
using BookManagementSystem.Application.Features.Base;
using BookManagementSystem.Application.Features.Book.Queries.GetBook;
using BookManagementSystem.Application.UnitOfWork;

namespace BookManagementSystem.Application.Features.Book.Queries.GetBookWithDetails;

public class GetBookWithDetailsQueryHandler : BaseRequestHandler<GetBookWithDetailsQuery, BookWithDetailsDTO>
{
    public GetBookWithDetailsQueryHandler(IMapper mapper, IApplicationUnitOfWorkCache cache, IApplicationUnitOfWorkRepository repository, IAppLogger<BaseRequestHandler<GetBookWithDetailsQuery, BookWithDetailsDTO>> logger) : base(mapper, cache, repository, logger)
    {
    }

    protected override async Task<BookWithDetailsDTO> HandleCore(GetBookWithDetailsQuery request, CancellationToken cancellationToken)
    {
        var book = await _repository.Books.GetBookWithDetails(request.id);
        if (book == null)
            throw new NotFoundException(nameof(Book), request.id);

        return _mapper.Map<BookWithDetailsDTO>(book);
    }
}
