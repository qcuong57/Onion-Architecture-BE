using AutoMapper;
using MediatR;
using OA.Application.DTOs;
using OA.Domain.IRepositories;

namespace OA.Application.Features.Authors.Commands;

public class DeleteAuthorCommand : IRequest<AuthorDto>
{

    public int Id { get; set; }

    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, AuthorDto>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public DeleteAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<AuthorDto> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetAuthorById(request.Id);
            if (author == null)
            {
                throw new ApplicationException($"Author with id {request.Id} not found.");
            }

            await _authorRepository.DeleteAuthor(author);
            await _authorRepository.SaveChangesAsync(cancellationToken);
            return _mapper.Map<AuthorDto>(author);
        }

    }
}