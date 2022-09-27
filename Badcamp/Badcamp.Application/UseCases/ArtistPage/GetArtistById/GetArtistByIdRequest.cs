using Badcamp.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.ArtistPage
{
	public class GetArtistByIdRequest : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
