using MediatR;
using OA.Application.DTOs;

namespace OA.Application.Features.Login.LoginCommand;

public class LoginCommand : IRequest<LoginResponse>
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}