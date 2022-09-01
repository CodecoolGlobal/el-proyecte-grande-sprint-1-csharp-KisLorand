using Badcamp.Models;
using Badcamp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Badcamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserStorage _userStorage;

        public UserController(UserStorage userStorage)
        {
            _userStorage = userStorage;
        }

        [HttpGet("/GetUsers")]
        public IEnumerable<User> GetAllUsers()
        {
            return _userStorage.GetAllUsers();
        }

        [HttpGet("/GetUser/{userName}")]
        public User GetUser([FromRoute] string userName)
        {
            return _userStorage.GetUserByName(userName);
        }

        [HttpPost("/RegisterUser")]
        public void RegisterUser([FromBody] User newUser)
        {
            _userStorage.AddUser(newUser);
        }

        [HttpPut("/UpdateUser/{userName}")]
        public void UpdateUser([FromRoute] string userName, [FromBody] User updatedUser)
        {
            _userStorage.UpdateUserData(userName, updatedUser);
        }

    }
}
