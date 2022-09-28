using Badcamp.Application.UseCases.ArtistGalleryCases;
using Badcamp.Models;
using Badcamp.Services;
using Microsoft.AspNetCore.Mvc;



namespace Badcamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistGalleryController : ControllerBase
    {

        private ArtistStorage _artistStorage;

        private ILogger<ArtistGalleryController> _logger;
        public ArtistGalleryController(ILogger<ArtistGalleryController> logger, ArtistStorage artistStoreage)
        {
            _artistStorage = artistStoreage;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IReadOnlyList<ArtistModel>> GetAllArtist()
        {
            var request = new GetAllArtistsHandlerRequest();
            var handler = new GetAllArtistsHandler(_artistStorage);
            var response = handler.Handle(request);
            if (response.Failure)
            {
                _logger.LogError(response.Error);
                return BadRequest(response.Error);
            }
            _logger.LogInformation("user received");
            return Ok(response.Value);
        }

 
    }
}
