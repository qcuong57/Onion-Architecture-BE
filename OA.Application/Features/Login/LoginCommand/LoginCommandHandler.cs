using MediatR;
using OA.Application.DTOs;
using OA.Domain.IServices;

namespace OA.Application.Features.Login.LoginCommand;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IUserService _userService;
        
    public LoginCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userService.Authenticate(request.Email, request.Password);

        if (user == null)
        {
            Console.WriteLine("Authentication failed: Invalid email or password.");
            return new LoginResponse
            {
                Success = false,
                Message = "Invalid email or password"
            };
        }

        // Assuming token generation logic here
        var token = "some-generated-token";

        return new LoginResponse
        {
            Success = true,
            Token = token,
            Message = "Login successful"
        };
    }
}