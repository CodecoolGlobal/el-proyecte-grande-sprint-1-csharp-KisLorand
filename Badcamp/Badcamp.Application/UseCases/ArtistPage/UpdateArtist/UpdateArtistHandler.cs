using Badcamp.Application.Common;
using Badcamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.ArtistPage.UpdateArtist
{
	public class UpdateArtistHandler : IRequestHandler<UpdateArtistRequest, Response<ArtistModel>>
	{
		private ArtistStorage _storage;
		public UpdateArtistHandler(ArtistStorage storage)
		{
			_storage = storage;
		}

		public Response<ArtistModel> Handle(UpdateArtistRequest message)
		{
			try
			{
				var updateData = message.Artist;
				ArtistModel artist = _storage.GetArtist(updateData.Id);
				artist.Name = updateData.Name;
				artist.Description = updateData.Description;
				artist.ArtistGenre = updateData.ArtistGenre;
				artist.ProfilePicture = updateData.ProfilePicture;
				if (artist == null)
				{
					return Response.Fail<ArtistModel>("Artist not found");
				}
				return Response.Ok(artist);
			}
			catch (Exception ex)
			{
				return Response.Fail<ArtistModel>(ex.Message);
			}
		}
	}
}
