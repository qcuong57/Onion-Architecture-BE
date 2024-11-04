using OA.Domain.Entities;
using OA.Domain.IRepositories;
using OA.Persistence.Context;

namespace OA.Infrastructure.Repositories;

public class AuthorRepository(ApplicationDbContext context) : IAuthorRepository
{
    public IQueryable<Author> GetAuthors()
    {
        return context.Authors;
    }

    public async Task<Author> GetAuthorById(int id)
    {
        return await context.Authors.FindAsync(id);
    }
    
    public async Task<Author> UpdateAuthor(Author author)
    {
        context.Authors.Update(author);
        await context.SaveChangesAsync();
        return author;
    }
    
    public async Task<Author> DeleteAuthor(Author author)
    {
        context.Authors.Remove(author);
        await context.SaveChangesAsync();
        return author;
    }
    
    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
    
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
    
    public async Task AddAsync(Author author, CancellationToken cancellationToken)
    {
        await context.Authors.AddAsync(author, cancellationToken);
    }

}