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
    }
}
