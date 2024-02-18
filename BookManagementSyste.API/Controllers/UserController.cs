using BookManagementSystem.API.Controllers.Base;
using BookManagementSystem.Application.Features.User.Queries.GetUserDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace BookManagementSystem.API.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : BaseController
{
    public UserController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("getSingleUser{id}")]
    public async Task<UserDetailsDTO> GetSingeUser(Guid id)
    {
        return await _mediator.Send(new GetUserDetailsQuery(id));
    }
}
