namespace Badcamp.Services
{
    public class ArtistGalleryService
    {
        private ArtistStorage _artistStorage;

        public ArtistGalleryService(ArtistStorage artistStorage)
        {
            _artistStorage = artistStorage;
        }
    }
}
