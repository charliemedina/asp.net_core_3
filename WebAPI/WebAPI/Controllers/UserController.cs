using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(_mapper.Map<IEnumerable<User>, IEnumerable<UserModel>>(users));
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUser(int id)
        {
            var user = await _userService.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return _mapper.Map<User, UserModel>(user);
        }

        // PUT: api/users/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> UpdateUser(int id, [FromBody] UserModel user)
        {

            var userToBeUpdate = await _userService.GetUser(id);

            if (userToBeUpdate == null)
                return NotFound();

            var updatedUser = await _userService.UpdateUser(id, user);

            return  Ok(_mapper.Map<User, UserModel>(updatedUser));
        }

        // POST: api/users
        [HttpPost]
        public async Task<ActionResult<UserModel>> CreateUser([FromBody] UserModel user)
        {
            var createdUser = await _userService.CreateUser(user);

            return Ok(_mapper.Map<User, UserModel>(createdUser));
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);

            return Ok();
        }
    }
}
