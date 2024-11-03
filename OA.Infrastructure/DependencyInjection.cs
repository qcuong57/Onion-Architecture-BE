using Microsoft.Extensions.DependencyInjection;
using OA.Infrastructure.Repositories;
using OA.Domain.IRepositories;

namespace OA.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }

}