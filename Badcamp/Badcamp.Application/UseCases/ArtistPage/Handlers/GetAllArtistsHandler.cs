using Badcamp.Application.Common;
using Badcamp.Application.UseCases.ArtistPage.Requests;
using Badcamp.Domain.Entities;
using Badcamp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.ArtistPage.Handlers
{
	public class GetAllArtistsHandler : IRequestHandler<GetAllArtistsRequest, Response<IReadOnlyList<Artist>>>
	{
		private ArtistStorage _storage;
		private IBadcampContext _context;
		public GetAllArtistsHandler(ArtistStorage storage)
		{
			_storage = storage;
		}
		public GetAllArtistsHandler(IBadcampContext context)
		{
			_context = context;
		}


		public Response<IReadOnlyList<Artist>> Handle(GetAllArtistsRequest message)
		{
			IReadOnlyList<Artist> artists;
			try
			{
				artists = _context.Artists.Include(x=>x.User).ToList();
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
