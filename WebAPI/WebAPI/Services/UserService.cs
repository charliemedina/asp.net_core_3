using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class UserService : IUserService
    {
        public UserService(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public async Task<User> CreateUser(UserModel model)
        {
            var user = new User
            {
                Address = model.Address,
                Age = model.Age,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber
            };

            await _userDbContext.Users.AddAsync(user);
            await _userDbContext.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUser(int id)
        {
            var user = await _userDbContext.Users.FindAsync(id);
            if (user != null)
            {
                _userDbContext.Users.Remove(user);
                await _userDbContext.SaveChangesAsync();
            }
        }

        public async Task<User> GetUser(int id)
        {
            return await _userDbContext.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userDbContext.Users.ToListAsync();
        }

        public async Task<User> UpdateUser(int id, UserModel user)
        {
            var userToBeUpdate = await _userDbContext.Users.FindAsync(id);

            userToBeUpdate.Address = user.Address;
            userToBeUpdate.Age = user.Age;
            userToBeUpdate.Email = user.Email;
            userToBeUpdate.FirstName = user.FirstName;
            userToBeUpdate.LastName = user.LastName;
            userToBeUpdate.PhoneNumber = user.PhoneNumber;

            await _userDbContext.SaveChangesAsync();

            return userToBeUpdate;
        }
       
        private readonly UserDbContext _userDbContext;
    }
}
