using BookManagementSystem.API.Controllers.Base;
using BookManagementSystem.Application.Features.User.Commands.AddUser;
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

    [HttpPost("add")]
    public async Task<Guid> AddUser(AddUserCommand command)
    {
        return await _mediator.Send(command);
    }
    [HttpGet("get{userId}")]
    public async Task<UserDetailsDTO> GetSingeUser(Guid userId)
    {
        var command = new GetUserDetailsQuery(userId);
        return await _mediator.Send(command);
    }
}
