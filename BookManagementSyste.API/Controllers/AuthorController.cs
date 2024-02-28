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

    [HttpGet("getTotalAuthorsItems")]
    public async Task<int> GetTotalAuthors()
    {
        var authors = await _mediator.Send(new GetAuthorsDropdownQuery());
        return authors.Count();
    }

    [HttpGet("getAuthorTotalPages")]
    public async Task<int> GetAuthorsTotalPages()
    {
        var authors = await _mediator.Send(new GetAuthorsPagedListQuery());
        return authors.TotalPages;
    }

    [HttpGet("getAuthorTotalItems")]
    public async Task<int> GetAuthorTotalItems()
    {
        var authors = await _mediator.Send(new GetAuthorsPagedListQuery());
        return authors.TotalItems;
    }

    [HttpPost("getAuthors")]
    public async Task<IReadOnlyList<AuthorPagedListDTO>> GetAuthorsPagedList(GetAuthorsPagedListQuery query)
    {
        var result = await _mediator.Send(query);
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
