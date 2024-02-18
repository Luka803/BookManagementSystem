using MediatR;

namespace BookManagementSystem.Application.Features.User.Queries.GetUserDetails;

public record GetUserDetailsQuery(Guid id) : IRequest<UserDetailsDTO>;
