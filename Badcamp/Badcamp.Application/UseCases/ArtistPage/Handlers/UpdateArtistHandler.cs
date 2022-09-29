using Badcamp.Application.Common;
using Badcamp.Application.UseCases.ArtistPage.Requests;
using Badcamp.Domain.Entities;
using Badcamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.ArtistPage.Handlers
{
	public class UpdateArtistHandler : IRequestHandler<ArtistRequest, Response<Artist>>
	{
		private ArtistStorage _storage;
		public UpdateArtistHandler(ArtistStorage storage)
		{
			_storage = storage;
		}

		public Response<Artist> Handle(ArtistRequest message)
		{
			try
			{
				var updateData = message.Artist;
				Artist artist = _storage.GetArtist(1);
				//Artist artist = _context.Artists.Where(x=>x.Id==updateData.Id);
				artist.Name = updateData.Name;
				artist.Description = updateData.Description;
				artist.Genres = updateData.Genres;
				artist.ProfilePicture = updateData.ProfilePicture;
				if (artist == null)
				{
					return Response.Fail<Artist>("Artist not found");
				}
				return Response.Ok(artist);
			}
			catch (Exception ex)
			{
				return Response.Fail<Artist>(ex.Message);
			}
		}
	}
}
