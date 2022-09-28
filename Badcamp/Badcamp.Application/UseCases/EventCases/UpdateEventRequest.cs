﻿using Badcamp.Application.Common;
using Badcamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.EventCases
{
    public class UpdateEventRequest : IRequest<Response>
    {
        public int EventId { get; set; }
        public Event UpdateEvent { get; set; } = new Event();
    }
}