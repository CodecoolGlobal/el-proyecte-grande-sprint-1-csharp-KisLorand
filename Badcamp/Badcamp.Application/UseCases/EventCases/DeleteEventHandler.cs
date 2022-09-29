﻿using Badcamp.Application.Common;
using Badcamp.Models;
using Badcamp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.EventCases
{
    public class DeleteEventHandler : IRequestHandler<DeleteEventRequest, Response<Event>>
    {
        //EventService _eventService;
        IBadcampContext _context;
        /* public DeleteEventHandler(EventService eventService)
         {
             _eventService = eventService;
         }*/
        public DeleteEventHandler(IBadcampContext context)
        {
            _context = context;
        }
        public Response<Event> Handle(DeleteEventRequest message)
        {
            /* Event @event;
             try
             {

                 @event = _context.Events.Find(message.EventId);
                 if (@event == null)
                 {
                     return Response.Fail<Event>("Couldn't be created");
                 }
                 _context.Events.Remove(@event);
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

