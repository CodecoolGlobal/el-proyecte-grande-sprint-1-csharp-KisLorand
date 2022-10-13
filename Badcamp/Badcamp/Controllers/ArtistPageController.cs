using Badcamp.Application;
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
		private IBadcampContext _context;
		public ArtistPageController(ArtistPageService artistPageservice, ILogger<ArtistPageController> logger, ArtistStorage artistStorage, IBadcampContext context)
		{
			_artistPageService = artistPageservice;
			_logger = logger;
			_artistStorage = artistStorage;
			_context = context;
		}

		[HttpGet]
		public ActionResult<IList<Artist>> GetAllArtists()
		{
			var request = new GetAllArtistsRequest();
			var handler = new GetAllArtistsHandler(_context);
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
			var handler = new GetArtistByIdHandler(_context);
			var response = handler.Handle(request);
			if (response.Failure)
			{
				_logger.LogError(response.Error);
				return BadRequest(response.Error);
			}
			_logger.LogInformation("Artist received");
			return Ok(response.Value);
		}

		[Route("{userId}/CreateArtist")]
		[HttpPost]
		public ActionResult<Artist> AddArtist([FromRoute] int userId, [FromBody] Artist newArtist)
		{
			var request = new ArtistAndIdRequest { Artist = newArtist, UserId= (long)userId };
			var handler = new AddArtistHandler(_context);
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
			var handler = new UpdateArtistHandler(_context);
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
			var handler = new DeleteArtistHandler(_context);
			var response = handler.Handle(request);
			if (response.Failure)
			{
				_logger.LogError(response.Error);
				return BadRequest(response.Error);
			}
			_logger.LogInformation("Artist deleted");
			return Ok(response.Value);
		}

		[HttpGet("Edit/{id}")]
		public ActionResult<Artist> GetOneArtistByUserId([FromRoute] int id)
		{
			var request = new ArtistIdRequest { Id = id };
			var handler = new GetArtistByUserIdHandler(_context);
			var response = handler.Handle(request);
			if (response.Failure)
			{
				_logger.LogError(response.Error);
				return BadRequest(response.Error);
			}
			_logger.LogInformation("Artist received");
			return Ok(response.Value);
		}
	}
}
