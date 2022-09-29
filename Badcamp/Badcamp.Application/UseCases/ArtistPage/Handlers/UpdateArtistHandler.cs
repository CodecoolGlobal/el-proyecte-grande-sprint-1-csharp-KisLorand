using Badcamp.Application.Common;
using Badcamp.Application.UseCases.ArtistPage.AddArtist;
using Badcamp.Domain.Entities;
using Badcamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.ArtistPage.UpdateArtist
{
	public class UpdateArtistHandler : IRequestHandler<ArtistModelRequest, Response<Artist>>
	{
		private ArtistStorage _storage;
		public UpdateArtistHandler(ArtistStorage storage)
		{
			_storage = storage;
		}

		public Response<Artist> Handle(ArtistModelRequest message)
		{
			try
			{
				var updateData = message.Artist;
				Artist artist = _storage.GetArtist(updateData.Id);
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
