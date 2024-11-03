using AutoMapper;
using MediatR;
using OA.Application.DTOs;
using OA.Domain.IRepositories;

namespace OA.Application.Features.User.Queries;

public class GetUserByIdQuery : IRequest<UserDto>
{
    public int Id { get; set; }

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.Id);
            return _mapper.Map<UserDto>(user);
        }
    }
    
}