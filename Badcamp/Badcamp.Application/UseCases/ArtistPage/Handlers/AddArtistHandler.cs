using Badcamp.Application.Common;
using Badcamp.Domain.Entities;
using Badcamp.Application.UseCases.ArtistPage.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.ArtistPage.Handlers
{
	public class AddArtistHandler : IRequestHandler<ArtistRequest, Response<Artist>>
	{
		private ArtistStorage _storage;
		public AddArtistHandler(ArtistStorage storage)
		{
			_storage = storage;
		}

		public Response<Artist> Handle(ArtistRequest message)
		{
			Artist artist = message.Artist;
			try
			{
				_storage.AddArtist(message.Artist);
				if (artist == null)
				{
					return Response.Fail<Artist>("Artists list not found");
				}
				return Response.Ok(artist);
			}
			catch (Exception e)
			{
				return Response.Fail<Artist>(e.Message);

			}
		}
	
	}
}
