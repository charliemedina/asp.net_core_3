using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace TestingTools
{
    public static class TestToolsExtensions
    {
        private static async Task<UserDbContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<UserDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new DatabaseContext(options);
            databaseContext.Database.EnsureCreated();
            if (await databaseContext.Users.CountAsync() <= 0)
            {
                for (int i = 1; i <= 10; i++)
                {
                    databaseContext.Users.Add(new User()
                    {
                        Id = i,
                        Email = $"testuser{i}@example.com",
                        IsLocked = false,
                        CreatedBy = "SYSTEM",
                        CreatedDate = DateTime.UtcNow
                    });
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }
    }
}
