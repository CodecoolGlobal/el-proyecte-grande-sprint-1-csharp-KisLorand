using Badcamp.Application.Common;
using Badcamp.Domain.Entities;
using Badcamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.EventCases
{
    public class CreateEventRequest : IRequest<Response>
    {
        public long ArtistId { get; set; }
        public Event NewEvent { get; set; }
        
    }
}
