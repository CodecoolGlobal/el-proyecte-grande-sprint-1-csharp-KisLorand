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
		[HttpGet]
		public ActionResult<IList<ArtistModel>> GetAllArtists()
		{
			//var artists = ArtistPageService.GetAll();
			return Ok("Echo");
		}

		[HttpGet("{id}")]
		public ActionResult<ArtistModel> GetOne(int id)
		{
			return Ok("Echo");
		}

		[HttpPost]
		public ActionResult<ArtistModel> Add()
		{
			return Ok("Echo");
		}
	}
}
