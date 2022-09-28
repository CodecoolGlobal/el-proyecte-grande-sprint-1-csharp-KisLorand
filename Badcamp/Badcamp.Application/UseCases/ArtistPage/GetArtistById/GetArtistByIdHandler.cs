using Badcamp.Application.Common;
using Badcamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.ArtistPage
{
	public class GetArtistByIdHandler : IRequestHandler<ArtistIdRequest, Response<ArtistModel>>
	{
		private ArtistStorage _storage;
		public GetArtistByIdHandler(ArtistStorage storage)
		{
			_storage = storage;
		}
		public Response<ArtistModel> Handle(ArtistIdRequest message)
		{
			ArtistModel artist;
			try
			{
				artist = _storage.GetArtist(message.Id);
				if (artist == null)
				{
					return Response.Fail<ArtistModel>("Artist not found");
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
