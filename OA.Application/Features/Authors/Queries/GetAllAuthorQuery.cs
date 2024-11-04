using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OA.Application.DTOs;
using OA.Domain.IRepositories;

namespace OA.Application.Features.Authors.Queries;

public class GetAllAuthorQuery :  IRequest<List<AuthorDto>>
{
    public class GetAllAuthorQueryHandle : IRequestHandler<GetAllAuthorQuery, List<AuthorDto>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetAllAuthorQueryHandle(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<List<AuthorDto>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
        {
            var authors = await _authorRepository.GetAuthors().ToListAsync(cancellationToken);
            return _mapper.Map<List<AuthorDto>>(authors);
        }
    }
}

