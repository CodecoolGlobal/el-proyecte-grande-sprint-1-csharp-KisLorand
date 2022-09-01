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
		public ArtistPageController(ArtistPageService artistPageservice)
		{
			_artistPageService = artistPageservice;
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
			ArtistModel artist = _artistPageService.GetOne(id);
			return Ok(artist);
		}

		[HttpPost]
		public ActionResult<IList<ArtistModel>> AddArtist([FromBody] ArtistModel newArtist)
		{
			ArtistModel addedArtist = _artistPageService.Add(newArtist);
			return Ok(_artistPageService.GetAll());
		}

		[HttpPatch("{id}")]
		public ActionResult<ArtistModel> UpdateArtist([FromRoute] int id, [FromBody] ArtistModel newArtistData)
		{
			ArtistModel updatedArtist = _artistPageService.Update(id, newArtistData);
			return Ok(updatedArtist);
		}
	}
}
