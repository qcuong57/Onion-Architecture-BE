using OA.Domain.Entities;

namespace OA.Domain.IRepositories;

public interface IAuthorRepository
{
    IQueryable<Author> GetAuthors();
    Task<Author> GetAuthorById(int id);
    Task<Author> UpdateAuthor(Author author);
    Task<Author> DeleteAuthor(Author author);
    Task SaveChangesAsync();
    Task SaveChangesAsync(CancellationToken cancellationToken);
    Task AddAsync(Author author, CancellationToken cancellationToken);
    
}
