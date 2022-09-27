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
    public class GetAllEventsHandler : IRequestHandler<GetAllEventsRequest, Response<IReadOnlyList<Event>>>
    {
        EventService _eventService;
        public GetAllEventsHandler(EventService eventService)
        {
            _eventService = eventService;
        }
        public Response<IReadOnlyList<Event>> Handle(GetAllEventsRequest message)
        {
            IReadOnlyList<Event> events;
            try
            {
                events = _eventService.GetAllEvents();
                if (events == null)
                {
                    return Response.Fail<IReadOnlyList<Event>>("Events not found");
                }
                return Response.Ok(events);
            }
            catch (Exception e)
            {
                return Response.Fail<IReadOnlyList<Event>>(e.Message);

            }

        }
    }
}
