using Badcamp.Application.Common;
using Badcamp.Domain.Entities;
using Badcamp.Models;
using Badcamp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.EventCases
{
    public class CreateEventHandler : IRequestHandler<CreateEventRequest, Response<Event>>
    {
        IBadcampContext _context;
        /*public CreateEventHandler(EventService eventService)
        {
            _eventService = eventService;
        }
*/
        public CreateEventHandler(IBadcampContext context)
        {
            _context = context;
        }
        public Response<Event> Handle(CreateEventRequest message)
        {
            Event @event;
            Event newEvent;
            Artist artist;
            try
            {
                // @event = _eventService.CreateEvent(message.ArtistId, message.NewEvent);
                newEvent = message.NewEvent;
                artist = _context.Artists.Find(message.ArtistId);
                newEvent.Artist = artist;
                _context.Events.Add(newEvent);
                @event = _context.Events.Find(newEvent.Id);
                if (@event == null)
                {
                    return Response.Fail<Event>("Event couldn't be created");
                }

                return Response.Ok(@event);

            }
            catch (Exception e)
            {
                return Response.Fail<Event>(e.Message);

            }
        }
    }
}
