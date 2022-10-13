using Badcamp.Application;
using Badcamp.Application.UseCases.EventCases;
using Badcamp.Domain.Entities;
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
        private ILogger<EventController> _logger;
        private readonly IBadcampContext _badcampContext;

        public EventController(ILogger<EventController> logger, IBadcampContext badcampContext)
        {
            _logger = logger;
            _badcampContext = badcampContext;
        }

        [Route("{artistId}/Create")]
        [HttpPost]
        public ActionResult<Event> CreateNewEvent(int artistId, [FromBody] Event newEvent)
        {
            var request = new CreateEventRequest { ArtistId = artistId, NewEvent = newEvent };
            var handler = new CreateEventHandler(_badcampContext);
            var response = handler.Handle(request);
            if (response.Failure)
            {
                _logger.LogError(response.Error);
                return BadRequest(response.Error);
            }
            _logger.LogInformation("Event created");
            return Ok(response.Value);
        }

      /*  [Route("{artistId}/GetEventsByArtist")]
        [HttpGet]
        public ActionResult<List<Event>> GetEventsByArtist(int artistId)
        {
            var request = new GetEventByArtistRequest { ArtistId = artistId };
            var handler = new GetEventByArtistHandler(_badcampContext);
            var response = handler.Handle(request);
            if (response.Failure)
            {
                _logger.LogError(response.Error);
                return BadRequest(response.Error);
            }
            _logger.LogInformation("Events recieved");
            return Ok(response.Value);
        }*/

        [Route("GetEvents")]
        [HttpGet]
        public ActionResult<List<Event>> GetEvents()
        {
            var request = new GetAllEventsRequest {};
            var handler = new GetAllEventsHandler(_badcampContext);
            var response = handler.Handle(request);
            if (response.Failure)
            {
                _logger.LogError(response.Error);
                return BadRequest(response.Error);
            }
            _logger.LogInformation("Events received");
            return Ok(response.Value);
        }

        [Route("DeleteEvent/{eventId}")]
        [HttpDelete]
        public ActionResult<Event> DeleteEvent(int eventId)
        {
            var request = new DeleteEventRequest { EventId = eventId};
            var handler = new DeleteEventHandler(_badcampContext);
            var response = handler.Handle(request);
            if (response.Failure)
            {
                _logger.LogError(response.Error);
                return BadRequest(response.Error);
            }
            _logger.LogInformation("Event Deleted");
            return NoContent();
        }
        [Route("UpdateEvent")]
        [HttpPut]
        public ActionResult<Event> UpdateEvent([FromBody] Event eventUpdate)
        {
            var request = new UpdateEventRequest { UpdateEvent = eventUpdate };
            var handler = new UpdateEventHandler(_badcampContext);
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
