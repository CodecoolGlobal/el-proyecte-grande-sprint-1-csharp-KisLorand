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

		public ArtistModel GetOne([FromRoute] int id)
		{ 
			return _artistStorage.GetArtist(id);
		}

		public IList<ArtistModel> GetAll()
		{
			return _artistStorage.GetArtists();
		}

		public ArtistModel Add(ArtistModel artist)
		{
			throw new NotImplementedException();
		}
	}
}
