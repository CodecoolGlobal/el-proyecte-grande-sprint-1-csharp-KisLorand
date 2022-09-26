using Badcamp.Application.UseCases;
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
        private ILogger<UserController> _logger;
        public UserController(UserStorage userStorage , ILogger<UserController> logger)
        {
            _userStorage = userStorage;
            _logger = logger;
        }

        [HttpGet("/GetUsers")]
        public IEnumerable<User> GetAllUsers()
        {
            return _userStorage.GetAllUsers();
        }

        [HttpGet("/GetUser/{userName}")]
        public ActionResult<User> GetUser([FromRoute] string userName)
        {
            var request = new GetUserByNameRequest { UserName = userName };
            var handler = new GeUserByNameHandler(_userStorage);
            var response = handler.Handle(request);
            if (response.Failure)
            {
                _logger.LogError(response.Error);
                return BadRequest(response.Error);
            }
            _logger.LogInformation("user received");
            return Ok(response.Value);
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
