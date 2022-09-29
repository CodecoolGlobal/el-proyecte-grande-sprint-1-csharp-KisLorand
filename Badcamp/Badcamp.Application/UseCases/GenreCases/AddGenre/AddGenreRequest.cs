using Badcamp.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.GenreCases.AddGenre
{
    public class AddGenreRequest : IRequest<Response>
    {
        public string  Name { get; set; }
    }
}
