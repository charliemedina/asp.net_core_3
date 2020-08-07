using Bogus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.TestingTools
{
    public static class TestToolsExtension
    {
        public static async Task<UserDbContext> CreateContextWithFakeUsers(int count)
        {
            var databaseContext = CreateContext();

            if (await databaseContext.Users.CountAsync() <= 0)
            {
                for (int i = 1; i <= count; i++)
                {
                    databaseContext.Users.Add(CreateFakeUser(i));
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }

        public static UserDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<UserDbContext>()
                            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                            .Options;

            var databaseContext = new UserDbContext(options);
            databaseContext.Database.EnsureCreated();

            return databaseContext;
        }

        public static User CreateFakeUser(int id)
        {
            var testUsers = new Faker<User>()
                //Basic rules using built-in generators
                .RuleFor(u => u.Id, f => id)
                .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName())
                .RuleFor(u => u.LastName, (f, u) => f.Name.LastName())
                .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
                .RuleFor(u => u.PhoneNumber, (f, u) => f.Phone.PhoneNumber())
                .RuleFor(u => u.Age, (f, u) => f.Random.Number(18, 60))
                .RuleFor(u => u.Address, (f, u) => f.Address.FullAddress());

            var user = testUsers.Generate();

            return user;
        }
    }
}
