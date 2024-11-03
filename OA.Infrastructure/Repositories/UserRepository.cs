using OA.Domain.IRepositories;
using OA.Persistence.Context;
using OA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace OA.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    
    public IQueryable<User> GetUsers()
    {
        return context.Users;
    }

    public async Task<User> GetUserById(int id)
    {
        return await context.Users.FindAsync(id);
    }

    public async Task<User> GetUserByEmail(string email)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> CreateUser(User user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateUser(User user)
    {
        context.Users.Update(user);
        await context.SaveChangesAsync();
        return user;
    }

    public async Task<User> DeleteUser(User user)
    {
        context.Users.Remove(user);
        await context.SaveChangesAsync();
        return user;
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task AddAsync(User user, CancellationToken cancellationToken)
    {
        await context.Users.AddAsync(user, cancellationToken);
    }
    
}