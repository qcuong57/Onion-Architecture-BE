using OA.Application.DTOs;
using OA.Domain.IRepositories;
using OA.Domain.IServices;

namespace OA.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDto?> Authenticate(string email, string password)
    {
        var user = await _userRepository.GetUserByEmail(email);
        if (user == null || user.Password != password)
        {
            return null;
        }

        return new UserDto
        {
            Id = user.Id,
            Email = user.Email,
            Name = user.Name
        };
    }
}