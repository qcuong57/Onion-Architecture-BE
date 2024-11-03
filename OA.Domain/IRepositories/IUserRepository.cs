using OA.Domain.Entities;

namespace OA.Domain.IRepositories;

public interface IUserRepository
{
    IQueryable<User> GetUsers();
    Task<User> GetUserById(int id);
    Task<User> GetUserByEmail(string email);
    Task<User> CreateUser(User user);
    Task<User> UpdateUser(User user);
    Task<User> DeleteUser(User user);
    Task SaveChangesAsync();
    Task SaveChangesAsync(CancellationToken cancellationToken);
    Task AddAsync(User user, CancellationToken cancellationToken);
}