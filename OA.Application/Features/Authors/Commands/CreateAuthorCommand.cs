using AutoMapper;
using MediatR;
using OA.Application.DTOs;
using OA.Domain.Entities;
using OA.Domain.IRepositories;

namespace OA.Application.Features.Authors.Commands;

public class CreateAuthorCommand : IRequest<AuthorDto>
{
    public int AuthorId { get; set; }
    public string Name { get; set; } = default!;
    
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, AuthorDto>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public CreateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<AuthorDto> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = _mapper.Map<Author>(request);
            await _authorRepository.AddAsync(author, cancellationToken);
            await _authorRepository.SaveChangesAsync(cancellationToken);
            return _mapper.Map<AuthorDto>(author);
            
        }
    }
    
}