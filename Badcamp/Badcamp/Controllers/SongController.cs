using Badcamp.Application;
using Badcamp.Application.Common;
using Badcamp.Application.UseCases.SongCases;
using Badcamp.Domain.Entities;
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
        private readonly IBadcampContext _badcampContext;
        private readonly IRequestHandler<AddSongRequest, Response> _addSongHandler;
        private readonly IRequestHandler<DeleteSongRequest, Response> _deleteSongHandler;
        private readonly IRequestHandler<UpdateSongRequest, Response> _updateSongHandler;
        private readonly IRequestHandler<GetSongRequest, Response> _getSongHandler;
        private readonly IRequestHandler<GetAllSongsRequest, Response> _getAllSongsHandler;

        private ILogger<SongController> _logger;

        public SongController(
            IBadcampContext badcampContext,
            IRequestHandler<AddSongRequest, Response> addSongHandler,
            IRequestHandler<DeleteSongRequest, Response> deleteSongHandler,
            IRequestHandler<UpdateSongRequest, Response> updateSongHandler,
            IRequestHandler<GetSongRequest, Response> getSongHandler,
            IRequestHandler<GetAllSongsRequest, Response> getAllSongsHandler,
            ILogger<SongController> logger)
        {
            _badcampContext = badcampContext;
            _addSongHandler = addSongHandler;
            _deleteSongHandler = deleteSongHandler;
            _updateSongHandler = updateSongHandler;
            _getSongHandler = getSongHandler;
            _getAllSongsHandler = getAllSongsHandler;
            _logger = logger;
        }

        [Route("/addSong")]
        [HttpPost]
        public ActionResult AddNewSong([FromBody] AddSongRequest NewSong)
        {
            var response = _addSongHandler.Handle(NewSong);
            if (response.Failure)
            {
                _logger.LogError(response.Error);
                return BadRequest(response.Error);
            }
            _logger.LogInformation("Song Added");
            return Ok();
        }

        [HttpGet]
        [Route("getSong/{SongID}")]
        public ActionResult<Song> GetSong([FromRoute] int SongID)
        {
            var request = new GetSongRequest { Id = SongID };
            var handler = new GetSongHandler(_badcampContext);
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
            var handler = new GetAllSongsHandler(_badcampContext);
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
        public ActionResult DeleteSong([FromRoute] DeleteSongRequest song)
        {
            var response = _deleteSongHandler.Handle(song);
            if (response.Failure)
            {
                _logger.LogError(response.Error);
                return BadRequest(response.Error);
            }
            _logger.LogInformation("Song Deleted");
            return Ok();
        }

        [HttpPut]
        [Route("{SongID}/update")]
        public ActionResult UpdateSong([FromRoute] int SongID, [FromBody] Song song)
        {
            var request = new UpdateSongRequest { Id = SongID, updateData = song };
            var handler = new UpdateSongHandler(_badcampContext);
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
