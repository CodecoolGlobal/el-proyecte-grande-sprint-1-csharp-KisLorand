using Badcamp.Application.UseCases.SongCases;
using Badcamp.Models;
using Badcamp.Services;
using Badcamp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Badcamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongService _songService;
        private ILogger<SongController> _logger;

        public SongController(ISongService songService, ILogger<SongController> logger)
        {
            _songService = songService;
            _logger = logger;
        }


        [Route("addSong")]
        [HttpPost]
        public ActionResult<Song> AddNewSong([FromBody] Song NewSong)
        {
            var request = new AddSongRequest { NewSong = NewSong };
            var handler = new AddSongHandler(_songService);
            var response = handler.Handle(request);
            if (response.Failure)
            {
                _logger.LogError(response.Error);
                return BadRequest(response.Error);
            }
            _logger.LogInformation("Song Added");
            return Ok(response.Value);
        }

        [HttpGet]
        [Route("getSong/{SongID}")]
        public ActionResult<Song> GetSong([FromRoute] int SongID)
        {
            var request = new GetSongRequest { Id = SongID };
            var handler = new GetSongHandler(_songService);
            var response = handler.Handle(request);
            if (response.Failure)
            {
                _logger.LogError(response.Error);
                return BadRequest(response.Error);
            }
            _logger.LogInformation("Song Received");
            return Ok(response.Value);

        }

        [HttpGet]
        [Route("getallSongs")]
        public ActionResult<List<Song>> GetAllSongs()
        {
            var request = new GetAllSongsRequest { };
            var handler = new GetAllSongsHandler(_songService);
            var response = handler.Handle(request);
            if (response.Failure)
            {
                _logger.LogError(response.Error);
                return BadRequest(response.Error);
            }
            _logger.LogInformation("Songs Received");
            return Ok(response.Value);
        }

        [HttpDelete]
        [Route("{SongID}/delete")]
        public ActionResult DeleteSong([FromRoute] int SongID)
        {
            var request = new DeleteSongRequest { Id = SongID };
            var handler = new DeleteSongHandler(_songService);
            _logger.LogInformation("Song Deleted");
            return NoContent();
        }

        [HttpPut]
        [Route("{SongID}/update")]
        public ActionResult UpdateSong([FromRoute] int SongID, [FromBody] Song song)
        {
            var request = new UpdateSongRequest { Id = SongID, updateData = song };
            var handler = new UpdateSongHandler(_songService);
            var response = handler.Handle(request);
            if (response.Failure)
            {
                _logger.LogError(response.Error);
                return BadRequest(response.Error);
            }
            _logger.LogInformation("Song Updated");
            return Ok();
        }
    }
}
