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
        private EventService _eventService;
        public EventController(EventService service)
        {
            _eventService = service;
        }

        [Route("{artistId}/Create")]
        [HttpPost]
        public ActionResult<Event> CreateNewEvent([FromRoute]int artistId, [FromBody] Event newEvent)
        {
            Event createdEvent = _eventService.CreateEvent(artistId, newEvent);
            return Ok(createdEvent);
        }
    }
}
