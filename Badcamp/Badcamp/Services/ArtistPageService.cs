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

		public ActionResult<ArtistModel> GetOne(int id)
		{ 
			throw new NotImplementedException();
		}

		public IList<ArtistModel> GetAll()
		{
			return _artistStorage.GetAllArtists();
		}

		public void Add(ArtistModel artist)
		{
			throw new NotImplementedException();
		}
	}
}
