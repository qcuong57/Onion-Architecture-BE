using MediatR;
using Microsoft.AspNetCore.Mvc;
using OA.Application.Features.Authors.Commands;
using OA.Application.Features.Authors.Queries;

namespace Onion_Architecture.Controllers;

[ApiController]
[Route("api/authors")]
public class AuthorController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<UserController> _logger;
    
    public AuthorController(IMediator mediator, ILogger<UserController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAuthors()
    {
        try
        {
            var authors = await _mediator.Send(new GetAllAuthorQuery());
            return Ok(authors);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, ex.Message);
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAuthorById(int id)
    {
        try
        {
            var author = await _mediator.Send(new GetAuthorByIdQuery { Id = id });
            return Ok(author);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, ex.Message);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAuthor(CreateAuthorCommand command)
    {
        try
        {
            var author = await _mediator.Send(command);
            return Ok(author);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, ex.Message);
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAuthor(int id, UpdateAuthorCommand command)
    {
        try
        {
            command.Id = id;
            var author = await _mediator.Send(command);
            return Ok(author);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, ex.Message);
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAuthor(int id)
    {
        try
        {
            var author = await _mediator.Send(new DeleteAuthorCommand { Id = id });
            return Ok(author);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, ex.Message);
        }
    }
}