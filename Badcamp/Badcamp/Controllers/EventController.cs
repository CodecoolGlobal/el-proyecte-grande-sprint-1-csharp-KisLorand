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
        public ActionResult<Event> CreateNewEvent(int artistId, [FromBody] Event newEvent)
        {
            Event createdEvent = _eventService.CreateEvent(artistId, newEvent);
            return Ok(createdEvent);
        }

        [Route("{artistId}/GetEventsByArtist")]
        [HttpGet]
        public ActionResult<List<Event>> GetEventsByArtist(int artistId)
        {
            List<Event> eventList = _eventService.GetEventByArtist(artistId);
            return Ok(eventList);
        }

        [Route("GetEvents")]
        [HttpGet]
        public ActionResult<List<Event>> GetEvents()
        {
            List<Event> eventList = _eventService.Storage;
            return Ok(eventList);
        }

        [Route("{artistId}/DeleteEvent/{eventId}")]
        [HttpDelete]
        public ActionResult<List<Event>> DeleteEvent(int artistId, int eventId)
        {
            List<Event> events = _eventService.DeleteEvent(artistId, eventId);
            return Ok(events);
        }
        [Route("{artistId}/UpdateEvent/{eventId}")]
        [HttpPut]
        public ActionResult<List<Event>> UpdateEvent(int artistId, int eventId, [FromBody] Event eventUpdate)
        {
            List<Event> events = _eventService.UpdateEvent(artistId, eventId, eventUpdate);
            return Ok(events);
        }
    }
}
