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
            return _artistStorage.GetAllArtists().Where(a => a.ArtistGenre == genre).ToList();
        }

        public ArtistModel GetArtistById(int id)
        {
            return _artistStorage.GetArtist(id);
        }

        public IList<ArtistModel> GetAllArtists()
        {
            return _artistStorage.GetArtists();
        }

    }
}
