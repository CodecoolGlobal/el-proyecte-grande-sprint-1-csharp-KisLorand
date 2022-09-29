using Badcamp.Application.UseCases.ArtistPage.Handlers;
using Badcamp.Application.UseCases.ArtistPage.Requests;
using Badcamp.Domain.Entities;
using Badcamp.Services;
using Microsoft.AspNetCore.Mvc;

namespace Badcamp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ArtistPageController : ControllerBase
	{
		private ArtistPageService _artistPageService;
		private ILogger<ArtistPageController> _logger;
		private ArtistStorage _artistStorage;
		public ArtistPageController(ArtistPageService artistPageservice, ILogger<ArtistPageController> logger, ArtistStorage artistStorage)
		{
			_artistPageService = artistPageservice;
			_logger = logger;
			_artistStorage = artistStorage;
		}

		[HttpGet]
		public ActionResult<IList<Artist>> GetAllArtists()
		{
			var request = new GetAllArtistsRequest();
			var handler = new GetAllArtistsHandler(_artistStorage);
			var response = handler.Handle(request);
			if (response.Failure)
			{
				_logger.LogError(response.Error);
				return BadRequest(response.Error);
			}
			_logger.LogInformation("All Artists recived");
			return Ok(response.Value);
		}

		[HttpGet("{id}")]
		public ActionResult<Artist> GetOneArtist([FromRoute] int id)
		{
			var request = new ArtistIdRequest { Id = id};
			var handler = new GetArtistByIdHandler(_artistStorage);
			var response = handler.Handle(request);
			if (response.Failure)
			{
				_logger.LogError(response.Error);
				return BadRequest(response.Error);
			}
			_logger.LogInformation("Artist received");
			return Ok(response.Value);
		}

		[HttpPost]
		public ActionResult<Artist> AddArtist([FromBody] Artist newArtist)
		{
			var request = new ArtistRequest { Artist = newArtist };
			var handler = new AddArtistHandler(_artistStorage);
			var response = handler.Handle(request);
			if (response.Failure)
			{
				_logger.LogError(response.Error);
				return BadRequest(response.Error);
			}
			_logger.LogInformation("Artist added");
			return Ok(response.Value);
		}

		[HttpPut("{id}")]
		public ActionResult<Artist> UpdateArtist([FromRoute] int id, [FromBody] Artist newArtistData)
		{
			var request = new ArtistRequest { Artist = newArtistData };
			var handler = new UpdateArtistHandler(_artistStorage);
			var response = handler.Handle(request);
			if (response.Failure)
			{
				_logger.LogError(response.Error);
				return BadRequest(response.Error);
			}
			_logger.LogInformation("Artist updated");
			return Ok(response.Value);
		}

		[HttpDelete("{id}")]
		public ActionResult<Artist> DeleteArtist([FromRoute] int id)
		{
			var request = new ArtistIdRequest { Id = id };
			var handler = new DeleteArtistHandler(_artistStorage);
			var response = handler.Handle(request);
			if (response.Failure)
			{
				_logger.LogError(response.Error);
				return BadRequest(response.Error);
			}
			_logger.LogInformation("Artist deleted");
			return Ok(response.Value);
		}
	}
}
