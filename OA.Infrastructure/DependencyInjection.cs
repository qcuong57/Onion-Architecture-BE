using Microsoft.Extensions.DependencyInjection;
using OA.Infrastructure.Repositories;
using OA.Domain.IRepositories;
using OA.Domain.IServices;
using OA.Infrastructure.Services;

namespace OA.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IUserService, UserService>();
        return services;
    }

}