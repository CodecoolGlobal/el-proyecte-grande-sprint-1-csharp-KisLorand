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
    }
}
