using Badcamp.Application;
using Badcamp.Application.UseCases.LoginCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Badcamp.Controllers
{
    [ApiController, Route("/login")]
    public class AuthenticationController : ControllerBase
    {
        private ILogger<UserController> _logger;
        private IConfiguration _config;
        private readonly IBadcampContext _badcampContext;

        public AuthenticationController(ILogger<UserController> logger, IBadcampContext badcampContext, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            _badcampContext = badcampContext;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] LoginUserRequest userRequest)
        {
            var handler = new LoginUserHandler(_badcampContext);
            var response = handler.Handle(userRequest, _config);

            if (response.Failure)
            {
                _logger.LogError(response.Error);
                return BadRequest(response.Error);
            }

            _logger.LogInformation($"{userRequest.Username} logged in!");
            return Ok(response);
        }    
        
    }
}
