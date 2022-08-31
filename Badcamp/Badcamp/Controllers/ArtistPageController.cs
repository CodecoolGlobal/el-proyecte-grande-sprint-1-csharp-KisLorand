using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Badcamp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ArtistPageController : ControllerBase
	{
		[HttpGet]
		public ActionResult<string> GetAll()
		{
			return Ok("Echo");
		}
	}
}
