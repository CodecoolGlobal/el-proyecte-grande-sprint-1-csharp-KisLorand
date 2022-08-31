using Badcamp.Models;
using Badcamp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Badcamp.Controllers
{   
    
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private EventStorage eventStorage;
        public EventController(EventStorage storage)
        {
            eventStorage = storage;
        }

        [Route("{artistId}/Create")]
        [HttpPost]
        public ActionResult<Event> CreateNewEvent([FromRoute]int artistId, [FromBody] Event newEvent)
        {
            Event createdEvent = eventStorage.CreateEvent(artistId, newEvent);
            return Ok(createdEvent);
        }
    }
}
