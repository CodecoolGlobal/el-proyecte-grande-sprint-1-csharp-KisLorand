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
		public ActionResult<ArtistModel> GetOne(int id)
		{
			ArtistModel artist = _artistPageService.GetOne(id);
			return Ok(artist);
		}

		[HttpPost]
		public ActionResult<ArtistModel> Add()
		{
			return Ok("Echo");
		}
	}
}
