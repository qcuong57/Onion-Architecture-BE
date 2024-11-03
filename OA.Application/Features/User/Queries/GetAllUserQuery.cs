using AutoMapper;
using MediatR;
using OA.Application.DTOs;
using OA.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace OA.Application.Features.User.Queries
{
    public class GetAllUsersQuery : IRequest<List<UserDto>>
    {
        public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
            {
                var users = await _userRepository.GetUsers().ToListAsync(cancellationToken);
                return _mapper.Map<List<UserDto>>(users);
            }
        }
    }
}