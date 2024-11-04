using AutoMapper;
using MediatR;
using OA.Application.DTOs;
using OA.Domain.IRepositories;

namespace OA.Application.Features.Authors.Queries;

public class GetAuthorByIdQuery : IRequest<AuthorDto>
{
    public int Id { get; set; }
    
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, AuthorDto>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetAuthorByIdQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<AuthorDto> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetAuthorById(request.Id);
            return _mapper.Map<AuthorDto>(author);
        }
    }
    
}