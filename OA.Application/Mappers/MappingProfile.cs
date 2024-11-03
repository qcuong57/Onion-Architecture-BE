using AutoMapper;
using OA.Application.DTOs;
using OA.Application.Features.User.Commands;
using OA.Domain.Entities;

namespace ClassLibrary1.Mappers;

public class MapppingProfile : Profile
{
    public MapppingProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<CreateUserCommand, User>();
    }
}