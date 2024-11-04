using AutoMapper;
using MediatR;
using OA.Application.DTOs;
using OA.Domain.IRepositories;

namespace OA.Application.Features.User.Commands;

public class DeleteUserCommand : IRequest<UserDto>
{
    public int Id { get; set; }
    
    public class DeleteUserCommandHandle : IRequestHandler<DeleteUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        
        public DeleteUserCommandHandle( IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        
        public async Task<UserDto> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.Id);
            if (user == null)
            {
                throw new ApplicationException($"User with id {request.Id} not found.");
            }
            await _userRepository.DeleteUser(user);
            await _userRepository.SaveChangesAsync(cancellationToken);
            return _mapper.Map<UserDto>(user);
        }
    }
}