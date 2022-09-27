using Badcamp.Application.UseCases.ArtistPage;
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
			var artists = _artistPageService.GetAll();
			return Ok(artists);
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
		public ActionResult<IList<ArtistModel>> AddArtist([FromBody] ArtistModel newArtist)
		{
			ArtistModel addedArtist = _artistPageService.Add(newArtist);
			return Ok(_artistPageService.GetAll());
		}

		[HttpPut("{id}")]
		public ActionResult<ArtistModel> UpdateArtist([FromRoute] int id, [FromBody] ArtistModel newArtistData)
		{
			ArtistModel updatedArtist = _artistPageService.Update(id, newArtistData);
			return Ok(updatedArtist);
		}
	}
}
