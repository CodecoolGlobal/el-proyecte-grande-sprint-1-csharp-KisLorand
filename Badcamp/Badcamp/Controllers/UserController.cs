using Badcamp.Application.UseCases;
using Badcamp.Application.UseCases.UserCases.AddUser;
using Badcamp.Application.UseCases.UserCases.UpdateUserDataCase;
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
        public ActionResult<User> RegisterUser([FromBody] AddUserRequest newUser)
        {
            var handler = new AddUserHandler(_userStorage);
            var response = handler.Handle(newUser);
            if (response.Failure)
            {
                _logger.LogError(response.Error);
                return BadRequest(response.Error);
            }
            _logger.LogInformation("user added");
            return Ok(response.Value);
        }

        [HttpPut("/UpdateUser/{userName}")]
        public ActionResult<User> UpdateUser([FromRoute] string userName, [FromBody] User updatedUser)
        {
            var request = new UpdateUserDataRequest { UserName = userName, UpdatedUser = updatedUser };
            var handler = new UpdateUserDataHandler(_userStorage);
            var response = handler.Handle(request);
            if (response.Failure)
            {
                _logger.LogError(response.Error);
                return BadRequest(response.Error);
            }
            _logger.LogInformation("user updated");
            return Ok(response.Value);
        }

    }
}
