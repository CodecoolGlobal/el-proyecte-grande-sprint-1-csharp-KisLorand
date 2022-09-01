using Badcamp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Badcamp.Services
{
	public class ArtistPageService
	{
		private ArtistStorage _artistStorage;

		public ArtistPageService(ArtistStorage storage)
		{
			_artistStorage = storage;
		}

		public ArtistModel GetOne(int id)
		{
			return _artistStorage.GetArtist(id);
		}

		public IList<ArtistModel> GetAll()
		{
			return _artistStorage.GetArtists();
		}

		public ArtistModel Add([FromBody] ArtistModel artist)
		{
			_artistStorage.AddArtist(artist);
			return artist;
		}

		public ArtistModel Update([FromRoute] int id, [FromBody] ArtistModel newArtistData)
		{
			ArtistModel updatedArtist = _artistStorage.GetArtist(id);
			UpdateArtistData(newArtistData, updatedArtist);
			return updatedArtist;
		}

		private void UpdateArtistData(ArtistModel newArtistData, ArtistModel updatedArtist)
		{
			updatedArtist.Name = newArtistData.Name;
			updatedArtist.Description = newArtistData.Description;
			updatedArtist.ArtistGenre = newArtistData.ArtistGenre;
			updatedArtist.ProfilePicture = newArtistData.ProfilePicture;
		}
	}
}
