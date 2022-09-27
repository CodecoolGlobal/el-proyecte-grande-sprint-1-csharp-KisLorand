using Badcamp.Application.UseCases.EventCases;
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
        private ILogger<EventController> _logger;

        public EventController(EventService service, ILogger<EventController> logger)
        {
            _eventService = service;
            _logger = logger;
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
            var request = new GetEventByArtistRequest { ArtistId = artistId };
            var handler = new GetEventByArtistHandler(_eventService);
            var response = handler.Handle(request);
            if (response.Failure)
            {
                _logger.LogError(response.Error);
                return BadRequest(response.Error);
            }
            _logger.LogInformation("user received");
            return Ok(response.Value);
        }

        [Route("GetEvents")]
        [HttpGet]
        public ActionResult<List<Event>> GetEvents()
        {
            var request = new GetAllEventsRequest {};
            var handler = new GetAllEventsHandler(_eventService);
            var response = handler.Handle(request);
            if (response.Failure)
            {
                _logger.LogError(response.Error);
                return BadRequest(response.Error);
            }
            _logger.LogInformation("user received");
            return Ok(response.Value);
        }

        [Route("{artistId}/DeleteEvent/{eventId}")]
        [HttpDelete]
        public ActionResult<IReadOnlyList<Event>> DeleteEvent(int artistId, int eventId)
        {
            IReadOnlyList<Event> events = _eventService.DeleteEvent(artistId, eventId);
            return Ok(events);
        }
        [Route("{artistId}/UpdateEvent/{eventId}")]
        [HttpPut]
        public ActionResult<IReadOnlyList<Event>> UpdateEvent(int artistId, int eventId, [FromBody] Event eventUpdate)
        {
            IReadOnlyList<Event> events = _eventService.UpdateEvent(artistId, eventId, eventUpdate);
            return Ok(events);
        }
    }
}
