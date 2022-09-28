using Badcamp.Application.Common;
using Badcamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.ArtistPage.AddArtist
{
	public class AddArtistHandler : IRequestHandler<ArtistModelRequest, Response<ArtistModel>>
	{
		private ArtistStorage _storage;
		public AddArtistHandler(ArtistStorage storage)
		{
			_storage = storage;
		}

		public Response<ArtistModel> Handle(ArtistModelRequest message)
		{
			ArtistModel artist = message.Artist;
			try
			{
				_storage.AddArtist(message.Artist);
				if (artist == null)
				{
					return Response.Fail<ArtistModel>("Artists list not found");
				}
				return Response.Ok(artist);
			}
			catch (Exception e)
			{
				return Response.Fail<ArtistModel>(e.Message);

			}
		}
	
	}
}
