using Badcamp.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Badcamp.Application.UseCases.PlaylistCases.CreatePlaylist;

namespace Badcamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {

        private IBadcampContext _context;

        private ILogger _logger;
        public PlaylistController(IBadcampContext context, ILogger<PlaylistController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost("CreatePlaylist")]
        public IActionResult CreatePlaylist([FromBody] CreatePlaylistRequest PlaylistReq)
        {
            var handler = new CreatePlaylistHandler(_context);
            var response = handler.Handle(PlaylistReq);
            if (response.Failure)
            {
                _logger.LogError(response.Error);
                return BadRequest(response.Error);
            }
            _logger.LogInformation($"{PlaylistReq.Name} Playlist created.");
            return Ok(response.Value);
        }

    }
}
