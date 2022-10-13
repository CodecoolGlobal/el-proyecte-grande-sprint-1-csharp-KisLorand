using Badcamp.Application.Common;
using Badcamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.ArtistPage.Requests
{
	public class ArtistAndIdRequest : IRequest<Response>
	{
		public Artist Artist;
		public long UserId;
	}
}
