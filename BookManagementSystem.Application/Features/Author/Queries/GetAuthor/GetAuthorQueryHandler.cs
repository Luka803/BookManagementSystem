using AutoMapper;
using BookManagementSystem.Application.Contracts.Logging;
using BookManagementSystem.Application.Contracts.UnitOfWork;
using BookManagementSystem.Application.Exceptions;
using BookManagementSystem.Application.Features.Base;

namespace BookManagementSystem.Application.Features.Author.Queries.GetAuthor;

public class GetAuthorQueryHandler : BaseQueryHandler<GetAuthorQuery, AuthorDetailsDTO>
{
    public GetAuthorQueryHandler(IMapper mapper, IApplicationUnitOfWorkCache cache, IApplicationUnitOfWorkRepository repository, IAppLogger<BaseQueryHandler<GetAuthorQuery, AuthorDetailsDTO>> logger) : base(mapper, cache, repository, logger)
    {
    }

    protected override async Task<AuthorDetailsDTO> HandleCore(GetAuthorQuery request, CancellationToken cancellationToken)
    {
        var author = await _repository.Author.GetAsync(request.ID);

        if (author == null)
            throw new NotFoundException(nameof(author), request.ID);

        _logger.LogInformation("Author with ID ({0}) successfully retrived", request.ID);
        return _mapper.Map<AuthorDetailsDTO>(author);
    }
}
