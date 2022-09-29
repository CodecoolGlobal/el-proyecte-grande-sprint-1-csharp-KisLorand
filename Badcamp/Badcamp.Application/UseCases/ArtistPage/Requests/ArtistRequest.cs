using Badcamp.Application.Common;
using Badcamp.Domain.Entities;
using System;

namespace Badcamp.Application.UseCases.ArtistPage.AddArtist
{
	public class ArtistRequest : IRequest<Response>
	{
		public Artist Artist;
	}
}
