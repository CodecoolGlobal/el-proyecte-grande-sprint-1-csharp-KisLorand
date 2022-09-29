using Badcamp.Domain.Entities;
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

        public IList<Artist> FilterArtistsByGenre(Genre genre)
        {
            throw new NotImplementedException();
            //return _artistStorage.GetArtists().Where(a => a.ArtistGenre == genre).ToList();
        }

        public Artist GetArtistById(int id)
        {
            return _artistStorage.GetArtist(id);
        }

        public IList<Artist> GetAllArtists()
        {
            return _artistStorage.GetArtists();
        }

        public Artist GetArtistByName(string name)
        {
            return _artistStorage.GetArtists().SingleOrDefault(a => a.Name == name);

        }

    }
}
