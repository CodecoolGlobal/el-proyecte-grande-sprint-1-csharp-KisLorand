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
            var request = new CreateEventRequest { ArtistId = artistId, NewEvent = newEvent };
            var handler = new CreateEventHandler(_eventService);
            var response = handler.Handle(request);
            if (response.Failure)
            {
                _logger.LogError(response.Error);
                return BadRequest(response.Error);
            }
            _logger.LogInformation("Event created");
            return Ok(response.Value);
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
            _logger.LogInformation("Events recieved");
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
            _logger.LogInformation("Events received");
            return Ok(response.Value);
        }

        [Route("{artistId}/DeleteEvent/{eventId}")]
        [HttpDelete]
        public ActionResult<IReadOnlyList<Event>> DeleteEvent(int artistId, int eventId)
        {
            IReadOnlyList<Event> events = _eventService.DeleteEvent(artistId, eventId);
            return NoContent();
        }
        [Route("{artistId}/UpdateEvent/{eventId}")]
        [HttpPut]
        public ActionResult<Event> UpdateEvent(int eventId, [FromBody] Event eventUpdate)
        {
            var request = new UpdateEventRequest { EventId = eventId, UpdateEvent = eventUpdate };
            var handler = new UpdateEventHandler(_eventService);
            var response = handler.Handle(request);
            if (response.Failure)
            {
                _logger.LogError(response.Error);
                return BadRequest(response.Error);
            }
            _logger.LogInformation("Event updated");
            return Ok(response.Value);
        }
    }
}
