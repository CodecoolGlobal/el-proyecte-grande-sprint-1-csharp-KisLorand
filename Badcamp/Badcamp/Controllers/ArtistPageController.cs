using Badcamp.Application.UseCases.ArtistPage;
using Badcamp.Application.UseCases.ArtistPage.AddArtist;
using Badcamp.Application.UseCases.ArtistPage.GetAllArtists;
using Badcamp.Application.UseCases.ArtistPage.UpdateArtist;
using Badcamp.Models;
using Badcamp.Services;
using Microsoft.AspNetCore.Http;
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
		public ActionResult<IList<ArtistModel>> GetAllArtists()
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
		public ActionResult<ArtistModel> GetOneArtist([FromRoute] int id)
		{
			var request = new GetArtistByIdRequest { Id = id};
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
		public ActionResult<ArtistModel> AddArtist([FromBody] ArtistModel newArtist)
		{
			var request = new AddArtistRequest { Artist = newArtist};
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
		public ActionResult<ArtistModel> UpdateArtist([FromRoute] int id, [FromBody] ArtistModel newArtistData)
		{
			var request = new UpdateArtistRequest { Artist = newArtistData };
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
	}
}
