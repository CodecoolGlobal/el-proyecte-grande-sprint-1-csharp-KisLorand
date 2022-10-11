using Badcamp.Application;
using Badcamp.Application.UseCases;
using Badcamp.Domain.Entities;
using Badcamp.Application.UseCases.UserCases.AddUser;
using Badcamp.Application.UseCases.UserCases.UpdateUserDataCase;
using Badcamp.Application.UseCases.UserCases.GetAllUsersCase;
using Microsoft.AspNetCore.Mvc;
using Badcamp.Application.UseCases.UserCases.DeleteUserCase;
using Microsoft.AspNetCore.Authorization;

namespace Badcamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ILogger<UserController> _logger;
        private readonly IBadcampContext _badcampContext;

        public UserController(ILogger<UserController> logger , IBadcampContext badcampContext)
        {
            _logger = logger;
            _badcampContext = badcampContext;
        }

        [HttpGet("/GetUsers")]
        public ActionResult<List<User>> GetAllUsers()
        {
            var request = new GetAllUsersRequest { };
            var handler = new GetAllUsersHandler(_badcampContext);
            var response = handler.Handle(request);
            if (response.Failure)
            {
                _logger.LogError(response.Error);
                return BadRequest(response.Error);
            }
            _logger.LogInformation("All users received!");
            return Ok(response.Value);
        }

        [HttpGet("/GetUser/{userName}")]
        public ActionResult<User> GetUser([FromRoute] string userName)
        {
            var request = new GetUserByNameRequest { UserName = userName };
            var handler = new GetUserByNameHandler(_badcampContext);
            var response = handler.Handle(request);
            if (response.Failure)
            {
                _logger.LogError(response.Error);
                return BadRequest(response.Error);
            }
            _logger.LogInformation("User received!");
            return Ok(response.Value);
        }

        [HttpPost("/RegisterUser")]
        public ActionResult<User> RegisterUser([FromBody] AddUserRequest newUser)
        {
            var handler = new AddUserHandler(_badcampContext);
            var response = handler.Handle(newUser);
            if (response.Failure)
            {
                _logger.LogError(response.Error);
                return BadRequest(response.Error);
            }
            _logger.LogInformation("User added!");
            return Ok(response.Value);
        }

        [HttpPut("/UpdateUser/{userName}")]
        public ActionResult<User> UpdateUser([FromRoute] string userName, [FromBody] User updatedUser)
        {
            var request = new UpdateUserDataRequest { UserName = userName, UpdatedUser = updatedUser };
            var handler = new UpdateUserDataHandler(_badcampContext);
            var response = handler.Handle(request);
            if (response.Failure)
            {
                _logger.LogError(response.Error);
                return BadRequest(response.Error);
            }
            _logger.LogInformation("User updated!");
            return Ok(response.Value);
        }

        [HttpDelete("/DeleteUser/{userName}")]
        public ActionResult<Event> DeleteUserByName([FromRoute] string userName)
        {
            var request = new DeleteUserByNameRequest { UserName = userName };
            var handler = new DeleteUserByNameHandler(_badcampContext);
            var response = handler.Handle(request);
            if (response.Failure)
            {
                _logger.LogError(response.Error);
                return BadRequest(response.Error);
            }
            _logger.LogInformation("User deleted!");
            return Ok(response.Value);
        }

    }
}
