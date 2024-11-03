using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OA.Persistence.Context;
using OA.Domain.Entities;

namespace OA.Persistence.Seeds;

public class ApplicationDbContextSeed
{
    public static async Task SeedSampleData(ApplicationDbContext context)
    {
        try
        {
            if (!await context.Users.AnyAsync())
            {
                var users = new List<User>
                {
                    new User { Name = "John Doe", Email = "john.doe@example.com", Password = "password123", Phone = "123-456-7890" },
                    new User { Name = "Jane Smith", Email = "jane.smith@example.com", Password = "password123", Phone = "098-765-4321" }
                };

                context.Users.AddRange(users);
                await context.SaveChangesAsync();
            }
            
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            var logger = new Logger<ApplicationDbContextSeed>(new LoggerFactory());
            logger.LogError(ex, ex.Message);
        }
    }
}