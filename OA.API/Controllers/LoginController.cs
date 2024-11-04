using MediatR;
using Microsoft.AspNetCore.Mvc;
using OA.Application.Features.Login.LoginCommand;

namespace Onion_Architecture.Controllers;

[ApiController]
[Route("api/login")]
public class LoginController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<UserController> _logger;
    
    public LoginController(IMediator mediator, ILogger<UserController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }
    
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.Success)
        {
            _logger.LogWarning("Login failed for user {Email}", command.Email);
            return Unauthorized(result);
        }

        _logger.LogInformation("User {Email} logged in successfully", command.Email);
        return Ok(result);
    }
}