using Badcamp.Application.Common;
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
            /* Event @event;
             try
             {
                 @event = _eventService.UpdateEvent(message.EventId, message.UpdateEvent);
                 if (@event == null)
                 {
                     return Response.Fail<Event>("Couldn't be created");
                 }
                 return Response.Ok(@event);

             }
             catch (Exception e)
             {
                 return Response.Fail<Event>(e.Message);

             }*/
            return Response.Ok<Event>(new Event());
        }
    }
}
