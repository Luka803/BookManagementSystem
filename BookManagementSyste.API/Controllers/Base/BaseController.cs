using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementSystem.API.Controllers.Base;
public abstract class BaseController : ControllerBase
{
    protected readonly IMediator _mediator;

    public BaseController(IMediator mediator)
    {
        this._mediator = mediator;
    }
}
