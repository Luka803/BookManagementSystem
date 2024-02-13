using BookManagementSystem.API.Controllers.Base;
using BookManagementSystem.Application.Features.Author.Commands.AddAuthor;
using BookManagementSystem.Application.Features.Author.Queries.GetAuthor;
using BookManagementSystem.Application.Features.Author.Queries.GetAuthors;
using BookManagementSystem.Application.Features.Author.Queries.GetAuthorsPagedList;
using BookManagementSystem.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementSyste.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController : BaseController
{
    public AuthorController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("GetAuthorsDropdown")]
    public async Task<List<AuthorDropdownDTO>> GetAuthorsDropdown()
    {
        return await _mediator.Send(new GetAuthorsDropdownQuery());
    }

    [HttpGet("GetAuthorsPagedList{page}")]
    public async Task<PagedListDTO<AuthorPagedListDTO>> GetAuthorsPagedList(int page)
    {
        return await _mediator.Send(new GetAuthorsPagedListQuery(page));
    }

    [HttpGet("{id}")]
    public async Task<AuthorDetailsDTO> GetSingleAuthor(Guid id)
    {
        return await _mediator.Send(new GetAuthorQuery(id));
    }

    [HttpPost("AddAuthor")]
    public async Task<Guid> AddAuthor(AddAuthorCommand addAuthorCommand)
    {
        return await _mediator.Send(addAuthorCommand);
    }

}
