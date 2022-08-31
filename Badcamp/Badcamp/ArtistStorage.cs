using Badcamp.Models;

namespace Badcamp
{
    public class ArtistStorage
    {

        private IList<ArtistModel> _artists;

        public ArtistStorage()
        {
            _artists = new List<ArtistModel>();
            CreateDummyData(10);
        }

        private void CreateDummyData(int dataCount)
        {
            for (int i = 0; i < dataCount; i++)
            {
                ArtistModel artist = new ArtistModel()
                {
                    Id = i,
                    Name = i.ToString() + "zoli",
                    ProfilePicture = i.ToString() + "imageRoute",
                    UserId = i + 2,
                    ArtistGenre = Genre.Rap
                };
                _artists.Add(artist);
            }
        }

        public ArtistModel CreateArtist(int id, string name, int userId, string desciption, string picture)
        {
            return new ArtistModel()
            {
                Id = id,
                Name = name,
                UserId = userId,
                Description = desciption,
                ProfilePicture = picture
            };
        }

        public void AddArtist(ArtistModel artist)
        {
            _artists.Add(artist);
        }

        public void DeleteArtist(ArtistModel artist)
        {
            _artists.Remove(artist);
        }

        public IList<ArtistModel> GetArtists()
        {
            return new List<ArtistModel>(_artists);
        }

        public ArtistModel GetArtist(int id)
        {
            return _artists.FirstOrDefault(a => a.Id == id);
        }

    }
}
