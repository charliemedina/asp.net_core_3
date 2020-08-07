using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();

        Task<User> GetUser(int id);

        Task<User> UpdateUser(int id, UserModel user);

        Task<User> CreateUser(UserModel user);

        Task DeleteUser(int id);
    }
}
