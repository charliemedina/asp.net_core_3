using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Services;
using WebAPI.TestingTools;

namespace UnitTesting
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public async Task CreateUser_Should_Return_All_Users()
        {
            // Arrange
            var service = await BuildService();
            UserModel model = CreateUserModel();

            // Act
            var actual = await service.CreateUser(model);

            // Assert
            Assert.AreEqual(model.Address, actual.Address);
        }

        [TestMethod]
        public async Task GetUsers_Should_Return_All_Users()
        {
            // Arrange
            var service = await BuildService();

            // Act
            var users = await service.GetUsers();

            // Assert
            Assert.AreEqual(users.Count(), 10);
        }

        [TestMethod]
        public async Task GetUser_Should_Return_An_Specific_User()
        {
            // Arrange
            var user = TestToolsExtension.CreateFakeUser(1);
            var dbContext = TestToolsExtension.CreateContext();
            await dbContext.AddAsync(user);
            var service = await BuildService(dbContext);

            // Act
            var actual = await service.GetUser(user.Id);

            // Assert
            Assert.AreEqual(user, actual);
        }

        [TestMethod]
        public async Task UpdateUser_Should_Return_User_Updated()
        {
            // Arrange
            var userToUpdate = TestToolsExtension.CreateFakeUser(1);
            var dbContext = TestToolsExtension.CreateContext();
            await dbContext.AddAsync(userToUpdate);
            var service = await BuildService(dbContext);

            // Act
            var model = CreateUserModel();
            var actual = await service.UpdateUser(userToUpdate.Id, model);

            // Assert
            Assert.AreEqual(model.Address, actual.Address);
        }

        [TestMethod]
        public async Task DeleteUser_Should_Delete_Success()
        {
            // Arrange
            var dbContext = await TestToolsExtension.CreateContextWithFakeUsers(5);
            var service = await BuildService(dbContext);
            var firstUserId = dbContext.Users.ToList().First().Id;

            // Act
            await service.DeleteUser(firstUserId);
            var actual = dbContext.Users.FirstOrDefault(u => u.Id == firstUserId);

            // Assert
            Assert.IsNull(actual);
        }

        private async Task<UserService> BuildService(UserDbContext dbContext = null)
        {
            var context = dbContext ?? await TestToolsExtension.CreateContextWithFakeUsers(10);
            var service = new UserService(context);
            return service;
        }

        private UserModel CreateUserModel()
        {
            var fakeUser = TestToolsExtension.CreateFakeUser(1);
            var model = new UserModel
            {
                Address = fakeUser.Address,
                Age = fakeUser.Age,
                Email = fakeUser.Email,
                FirstName = fakeUser.FirstName,
                LastName = fakeUser.LastName,
                PhoneNumber = fakeUser.PhoneNumber
            };
            return model;
        }
    }
}
