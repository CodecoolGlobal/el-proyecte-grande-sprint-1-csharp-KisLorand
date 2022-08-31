using Microsoft.AspNetCore.Mvc;

namespace Badcamp.Controllers
{
    [ApiController]
    public class SongController : ControllerBase
    {
        [HttpGet]
        [Route("/api/[controller]/echotest")]
        public ActionResult<string> EchoTest()
        {
            return Ok("initial echo test.");
        }
    }
}
