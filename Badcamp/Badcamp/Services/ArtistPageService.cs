using Badcamp.Domain.Entities;
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

		public Artist GetOne(int id)
		{
			return _artistStorage.GetArtist(id);
		}

		public IList<Artist> GetAll()
		{
			return _artistStorage.GetArtists();
		}

		public Artist Add([FromBody] Artist artist)
		{
			_artistStorage.AddArtist(artist);
			return artist;
		}

		public Artist Update([FromRoute] int id, [FromBody] Artist newArtistData)
		{
			Artist updatedArtist = _artistStorage.GetArtist(id);
			UpdateArtistData(newArtistData, updatedArtist);
			return updatedArtist;
		}

		private void UpdateArtistData(Artist newArtistData, Artist updatedArtist)
		{
			updatedArtist.Name = newArtistData.Name;
			updatedArtist.Description = newArtistData.Description;
			updatedArtist.Genres = newArtistData.Genres;
			updatedArtist.ProfilePicture = newArtistData.ProfilePicture;
		}
	}
}
