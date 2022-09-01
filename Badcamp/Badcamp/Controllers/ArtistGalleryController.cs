using Badcamp.Models;
using Badcamp.Services;
using Microsoft.AspNetCore.Mvc;

namespace Badcamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistGalleryController
    {

        private ArtistGalleryService _artistGalleryService;
        public ArtistGalleryController(ArtistGalleryService artistGalleryService)
        {
            _artistGalleryService = artistGalleryService;
        }

        [HttpGet("/GetArtists")]
        public IList<ArtistModel> GetAllArtist()
        {
            return _artistGalleryService.GetAllArtists();
        }

        [HttpGet("/SearchArtist/{id}")]
        public ArtistModel SearchArtist([FromQuery] int id)
        {
            return _artistGalleryService.GetArtistById(id);
        }

 
    }
}
