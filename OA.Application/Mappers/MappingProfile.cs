using AutoMapper;
using OA.Application.DTOs;
using OA.Application.Features.Authors.Commands;
using OA.Application.Features.User.Commands;
using OA.Domain.Entities;

namespace ClassLibrary1.Mappers;

public class MapppingProfile : Profile
{
    public MapppingProfile()
    {
        //User
        CreateMap<User, UserDto>();
        CreateMap<CreateUserCommand, User>();
        CreateMap<UpdateUserCommand, User>();
        CreateMap<DeleteUserCommand, User>();
        
        //Author
        CreateMap<Author, AuthorDto>();
        CreateMap<CreateAuthorCommand, Author>();
        CreateMap<UpdateAuthorCommand, Author>();
        CreateMap<DeleteAuthorCommand, Author>();
        
    }
}