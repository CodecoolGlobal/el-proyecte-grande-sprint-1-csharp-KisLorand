﻿using Badcamp.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.EventCases
{
    public class DeleteEventRequest : IRequest<Response>
    {
        public int EventId { get; set; }
    }
}
