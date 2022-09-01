using Badcamp.Models;

namespace Badcamp.Services
{
    public class ArtistGalleryService
    {
        private ArtistStorage _artistStorage;

        public ArtistGalleryService(ArtistStorage artistStorage)
        {
            _artistStorage = artistStorage;
        }

        public IList<ArtistModel> FilterArtistsByGenre(Genre genre)
        {
            return _artistStorage.GetArtists().Where(a => a.ArtistGenre == genre).ToList();
        }

        public ArtistModel GetArtistById(int id)
        {
            return _artistStorage.GetArtist(id);
        }

        public IList<ArtistModel> GetAllArtists()
        {
            return _artistStorage.GetArtists();
        }

        public ArtistModel GetArtistByName(string name)
        {
            return _artistStorage.GetArtists().SingleOrDefault(a => a.Name == name);

        }

    }
}
