using AutoMapper;
using BookManagementSystem.Application.Contracts.Logging;
using BookManagementSystem.Application.Features.Base;
using BookManagementSystem.Application.UnitOfWork;

namespace BookManagementSystem.Application.Features.User.Queries.GetUserDetails;

public class GetUserDetailsQueryHandler : BaseRequestHandler<GetUserDetailsQuery, UserDetailsDTO>
{
    public GetUserDetailsQueryHandler(IMapper mapper, IApplicationUnitOfWorkCache cache, IApplicationUnitOfWorkRepository repository, IAppLogger<BaseRequestHandler<GetUserDetailsQuery, UserDetailsDTO>> logger) : base(mapper, cache, repository, logger)
    {
    }

    protected override async Task<UserDetailsDTO> HandleCore(GetUserDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.User.GetAsync(request.id);

        return _mapper.Map<UserDetailsDTO>(entity);
    }
}