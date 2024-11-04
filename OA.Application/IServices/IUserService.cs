using OA.Application.DTOs;

namespace OA.Domain.IServices;


public interface IUserService
{
    Task<UserDto?> Authenticate(string email, string password);
}