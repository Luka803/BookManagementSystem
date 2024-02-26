using BookManagementSystem.API.Controllers.Base;
using BookManagementSystem.Application.Features.Author.Commands.AddAuthor;
using BookManagementSystem.Application.Features.Author.Commands.DeleteAuthor;
using BookManagementSystem.Application.Features.Author.Commands.UpdateAuthor;
using BookManagementSystem.Application.Features.Author.Queries.GetAuthor;
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

    [HttpGet("getAuthorsDropdown")]
    public async Task<List<AuthorDropdownDTO>> GetAuthorsDropdown()
    {
        return await _mediator.Send(new GetAuthorsDropdownQuery());
    }

    [HttpGet("getAuthors/{page}")]
    public async Task<IReadOnlyList<AuthorPagedListDTO>> GetAuthorsPagedList(int page = 1)
    {
        var command = new GetAuthorsPagedListQuery(page);
        var result = await _mediator.Send(command);
        return result.Items;
    }

    [HttpGet("get/{authorId}")]
    public async Task<AuthorDetailsDTO> GetSingleAuthor(Guid authorId)
    {
        var command = new GetAuthorQuery(authorId);
        return await _mediator.Send(command);
    }
    [HttpPost("addAuthor")]
    public async Task<ActionResult<Guid>> AddAuthor(AddAuthorCommand addAuthorCommand)
    {
        var response = await _mediator.Send(addAuthorCommand);
        return Ok(response);
    }

    [HttpPut("updateAuthor")]
    public async Task<Guid> UpdateAuthor(UpdateAuthorCommand updateAuthorCommand)
    {
        return await _mediator.Send(updateAuthorCommand);
    }

    [HttpDelete("deleteAuthor")]
    public async Task<IActionResult> DeleteAuthor(DeleteAuthorCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

}
