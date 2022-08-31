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
		public ActionResult<string> GetAllArtists()
		{
			var artists = ArtistPageService.GetAll();
			return Ok("Echo");
		}

		[HttpGet]
		public ActionResult<string> GetOne(int id)
		{
			return Ok("Echo");
		}

		[HttpPost]
		public ActionResult<string> Add()
		{
			return Ok("Echo");
		}
	}
}
