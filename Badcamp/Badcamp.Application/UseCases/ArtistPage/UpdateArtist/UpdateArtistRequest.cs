using Badcamp.Application.Common;
using Badcamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.ArtistPage.UpdateArtist
{
	public class UpdateArtistRequest : IRequest<Response>
	{
		public ArtistModel Artist;
	}
}
