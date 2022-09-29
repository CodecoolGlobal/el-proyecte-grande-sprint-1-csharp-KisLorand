using Badcamp.Application.Common;
using Badcamp.Domain.Entities;
using Badcamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.ArtistPage.GetAllArtists
{
	public class GetAllArtistsHandler : IRequestHandler<GetAllArtistsRequest, Response<IReadOnlyList<Artist>>>
	{
		private ArtistStorage _storage;
		public GetAllArtistsHandler(ArtistStorage storage)
		{
			_storage = storage;
		}

		public Response<IReadOnlyList<Artist>> Handle(GetAllArtistsRequest message)
		{
			IReadOnlyList<Artist> artists;
			try
			{
				artists = _storage.GetArtists().ToList().AsReadOnly();
				if (artists == null)
				{
					return Response.Fail<IReadOnlyList<Artist>>("Artists list not found");
				}
				return Response.Ok(artists);
			}
			catch (Exception e)
			{
				return Response.Fail<IReadOnlyList<Artist>>(e.Message);

			}
		}
	}
}
