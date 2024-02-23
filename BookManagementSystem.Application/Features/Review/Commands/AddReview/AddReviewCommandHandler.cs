using AutoMapper;
using BookManagementSystem.Application.Contracts.Logging;
using BookManagementSystem.Application.Features.Base;
using BookManagementSystem.Application.UnitOfWork;

namespace BookManagementSystem.Application.Features.Review.Commands.AddReview;

public class AddReviewCommandHandler : BaseRequestHandler<AddReviewCommand, Guid>
{
    public AddReviewCommandHandler(IMapper mapper, IApplicationUnitOfWorkCache cache, IApplicationUnitOfWorkRepository repository, IAppLogger<BaseRequestHandler<AddReviewCommand, Guid>> logger) : base(mapper, cache, repository, logger)
    {
    }

    protected override async Task<Guid> HandleCore(AddReviewCommand request, CancellationToken cancellationToken)
    {
        var entityToAdd = _mapper.Map<MyDomain.Review>(request);

        await _repository.Review.CreateAsync(entityToAdd);

        return entityToAdd.ID;

    }
}
