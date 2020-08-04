using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Controllers;
using WebAPI.Services;
using WebAPI.TestingTools;

namespace UnitTesting
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public async Task Should_Return_All_Users()
        {
            // Arrange
            var service = await BuildService();

            // Act
            var users = await service.GetUsers();

            // Assert
            Assert.AreEqual(users.Count(), 10);
        }

        private static async Task<UserService> BuildService()
        {
            var dbContext = await TestToolsExtension.GetDatabaseContext(10);
            var service = new UserService(dbContext);
            return service;
        }
    }
}
