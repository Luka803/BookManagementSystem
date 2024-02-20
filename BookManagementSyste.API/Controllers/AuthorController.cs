using BookManagementSystem.API.Controllers.Base;
using BookManagementSystem.Application.Features.Author.Commands.AddAuthor;
using BookManagementSystem.Application.Features.Author.Commands.DeleteAuthor;
using BookManagementSystem.Application.Features.Author.Commands.UpdateAuthor;
using BookManagementSystem.Application.Features.Author.Queries.GetAuthor;
using BookManagementSystem.Application.Features.Author.Queries.GetAuthorBooksPagedList;
using BookManagementSystem.Application.Features.Author.Queries.GetAuthors;
using BookManagementSystem.Application.Features.Author.Queries.GetAuthorsPagedList;
using BookManagementSystem.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementSystem.API.Controllers;

[Route("api/author")]
[ApiController]
public partial class AuthorController : BaseController
{
    public AuthorController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("getDropdown")]
    public async Task<List<AuthorDropdownDTO>> GetAuthorsDropdown()
    {
        return await _mediator.Send(new GetAuthorsDropdownQuery());
    }

    [HttpGet("getPagedList{page}")]
    public async Task<PagedListDTO<AuthorPagedListDTO>> GetAuthorsPagedList(int page = 1)
    {
        return await _mediator.Send(new GetAuthorsPagedListQuery(page));
    }

    [HttpGet("get{Id}")]
    public async Task<AuthorDetailsDTO> GetSingleAuthor(Guid id)
    {
        return await _mediator.Send(new GetAuthorQuery(id));
    }
    [HttpPost("add")]
    public async Task<ActionResult<Guid>> AddAuthor(AddAuthorCommand addAuthorCommand)
    {
        var response = await _mediator.Send(addAuthorCommand);
        return Ok(response);
    }

    [HttpPut("update")]
    public async Task<Guid> UpdateAuthor(UpdateAuthorCommand updateAuthorCommand)
    {
        return await _mediator.Send(updateAuthorCommand);
    }

    [HttpDelete("delete{Id}")]
    public async Task<IActionResult> DeleteAuthor(Guid id)
    {
        var command = new DeleteAuthorCommand(id);
        await _mediator.Send(command);
        return Ok();
    }

}
