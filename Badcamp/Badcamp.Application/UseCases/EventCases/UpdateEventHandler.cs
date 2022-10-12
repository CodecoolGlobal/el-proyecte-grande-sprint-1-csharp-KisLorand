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
    public class UpdateEventHandler : IRequestHandler<UpdateEventRequest, Response<Event>>
    {
        //EventService _eventService;
        IBadcampContext _context;
       /* public UpdateEventHandler(EventService eventService)
        {
            _eventService = eventService;
        }*/

        public UpdateEventHandler(IBadcampContext context)
        {
            _context = context;
        }
        public Response<Event> Handle(UpdateEventRequest message)
        {
            Event? @event;
            try
            {
                // _context.Events.Update(message.UpdateEvent);
                @event = _context.Events.Find(message.UpdateEvent.Id);
                @event.Title = message.UpdateEvent.Title;
                @event.Description = message.UpdateEvent.Description;
                @event.Upvote = message.UpdateEvent.Upvote;
                _context.SaveChanges();
                @event = _context.Events.Find(message.UpdateEvent.Id);
                if (@event == null)
                {
                    return Response.Fail<Event>("Event Couldn't be updated");
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
