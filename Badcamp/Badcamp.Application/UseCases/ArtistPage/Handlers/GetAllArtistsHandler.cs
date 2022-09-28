using Badcamp.Application.Common;
using Badcamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.ArtistPage.GetAllArtists
{
	public class GetAllArtistsHandler : IRequestHandler<GetAllArtistsRequest, Response<IReadOnlyList<ArtistModel>>>
	{
		private ArtistStorage _storage;
		public GetAllArtistsHandler(ArtistStorage storage)
		{
			_storage = storage;
		}

		public Response<IReadOnlyList<ArtistModel>> Handle(GetAllArtistsRequest message)
		{
			IReadOnlyList<ArtistModel> artists;
			try
			{
				artists = _storage.GetArtists().ToList().AsReadOnly();
				if (artists == null)
				{
					return Response.Fail<IReadOnlyList<ArtistModel>>("Artists list not found");
				}
				return Response.Ok(artists);
			}
			catch (Exception e)
			{
				return Response.Fail<IReadOnlyList<ArtistModel>>(e.Message);

			}
		}
	}
}
