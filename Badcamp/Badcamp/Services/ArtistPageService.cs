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

		public ArtistModel Update(int id, [FromBody] ArtistModel artist)
		{
			ArtistModel updatedArtist = _artistStorage.GetArtist(id);
			updatedArtist.Name = artist.Name;
			updatedArtist.Description = artist.Description;
			updatedArtist.ArtistGenre = artist.ArtistGenre;
			updatedArtist.ProfilePicture = artist.ProfilePicture;
			return updatedArtist;
		}
	}
}
