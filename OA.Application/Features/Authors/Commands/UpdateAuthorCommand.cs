using AutoMapper;
using MediatR;
using OA.Application.DTOs;
using OA.Domain.Entities;
using OA.Domain.IRepositories;

namespace OA.Application.Features.Authors.Commands;

public class UpdateAuthorCommand : IRequest<AuthorDto>
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, AuthorDto>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public UpdateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<AuthorDto> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetAuthorById(request.Id);
            if (author == null)
            {
                throw new ApplicationException($"Author with id {request.Id} not found.");
            }
            
            author.Name = request.Name;
            
            await _authorRepository.UpdateAuthor(author);
            await _authorRepository.SaveChangesAsync(cancellationToken);
            return _mapper.Map<AuthorDto>(author);
        }
    }
}