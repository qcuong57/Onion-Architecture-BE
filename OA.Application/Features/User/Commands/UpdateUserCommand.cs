using AutoMapper;
using MediatR;
using OA.Application.DTOs;
using OA.Domain.IRepositories;

namespace OA.Application.Features.User.Commands;

public class UpdateUserCommand : IRequest<UserDto>
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; } = default!;
    public string Phone { get; set; }
    
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.Id);
            if (user == null)
            {
                throw new ApplicationException($"User with id {request.Id} not found.");
            }
            user.Email = request.Email;
            user.Password = request.Password;
            user.Name = request.Name;
            user.Phone = request.Phone;
            await _userRepository.UpdateUser(user);
            await _userRepository.SaveChangesAsync(cancellationToken);
            return _mapper.Map<UserDto>(user);
        }
    }
    
}