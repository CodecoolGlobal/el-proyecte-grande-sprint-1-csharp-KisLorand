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
    public class GetEventByArtistHandler : IRequestHandler<GetEventByArtistRequest, Response<IReadOnlyList<Event>>>
    {
       // EventService _eventService;
        IBadcampContext _context;
        /*public GetEventByArtistHandler(EventService eventService)
        {
            _eventService = eventService;
        }*/
        public GetEventByArtistHandler(IBadcampContext context)
        {
            _context = context;
        }
        public Response<IReadOnlyList<Event>> Handle(GetEventByArtistRequest message)
        {
            /* IReadOnlyList<Event> events;
             try
             {
                 events = null; _eventService.GetEventByArtist(message.ArtistId);
                 if (events == null)
                 {
                     return Response.Fail<IReadOnlyList<Event>>("Events not found");
                 }
                 return Response.Ok(events);
             }
             catch (Exception e)
             {
                 return Response.Fail<IReadOnlyList<Event>>(e.Message);

             }*/
            return Response.Ok<IReadOnlyList<Event>>(new List<Event>());

        }
    }
}
