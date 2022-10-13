using Badcamp.Application;
using Badcamp.Application.UseCases.GenreCases.GetAllGenres;
using Badcamp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Badcamp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : ControllerBase
    {

        private ILogger<GenreController> _logger;

        private readonly IBadcampContext _badcampContext;

        public GenreController(ILogger<GenreController> logger, IBadcampContext context)
        {
            _logger = logger;
            _badcampContext = context;
        }

        [HttpGet]
        public ActionResult<IReadOnlyList<string>> GetAllGenres()
        {
            var request = new GetAllGenresRequest { };
            var handler = new GetAllGenresHandler(_badcampContext);
            var response = handler.Handle(request);
            if (response.Failure)
            {
                _logger.LogError(response.Error);
                return BadRequest(response.Error);
            }
            _logger.LogInformation("All genres recived!");
            return Ok(response.Value);
        }
    }
}

