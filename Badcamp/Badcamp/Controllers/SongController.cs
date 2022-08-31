using Badcamp.Models;
using Badcamp.Services;
using Badcamp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Badcamp.Controllers
{
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongStorage _storage;

        public SongController(ISongStorage songStorage)
        {
            _storage = songStorage;
        }

        [HttpGet]
        [Route("{songID}")]
        public ActionResult<Song> GetSong([FromRoute] Guid songID)
        {
            Song song = _storage.GetSong(songID);
            return Ok(song);
        }

        [HttpGet]
        [Route("getall")]
        public ActionResult<List<Song>> GetAll()
        {
            List<Song>? response = _storage.GetAllSongs();
            return Ok(response);
        }

        [HttpDelete]
        [Route("{songID}/delete")]
        public ActionResult DeleteSong([FromRoute] Guid songID)
        {
            _storage.DeleteSong(songID);
            return Ok();
        }

        [HttpPut]
        [Route("{songID}/update")]
        public ActionResult UpdateSong([FromRoute] Guid songID, [FromBody] Song song)
        {
            _storage.UpdateSong(song);
            return Ok();
        }
    }
}
