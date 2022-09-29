using Badcamp.Domain.Entities;
using Badcamp.Models;

namespace Badcamp
{
    public class ArtistStorage
    {

        private IList<Artist> _artists;

        public ArtistStorage()
        {
            _artists = new List<Artist>();
            //CreateDummyData(10);
        }

        //private void CreateDummyData(int dataCount)
        //{
        //    for (int i = 0; i < dataCount; i++)
        //    {
        //        ArtistModel artist = new ArtistModel()
        //        {
        //            Id = i,
        //            Name = i.ToString() + "zoli",
        //            ProfilePicture = i.ToString() + "imageRoute",
        //            UserId = i + 2,
        //            ArtistGenre = Genre.Rap
        //        };
        //        _artists.Add(artist);
        //    }
        //}

        //public ArtistModel CreateArtist(int id, string name, int userId, string desciption, string picture)
        //{
        //    return new ArtistModel()
        //    {
        //        Id = id,
        //        Name = name,
        //        UserId = userId,
        //        Description = desciption,
        //        ProfilePicture = picture
        //    };
        //}

        public void AddArtist(Artist artist)
        {
            _artists.Add(artist);
        }

        public void DeleteArtist(Artist artist)
        {
            _artists.Remove(artist);
        }

        public IList<Artist> GetArtists()
        {
            return new List<Artist>(_artists);
        }

        public Artist GetArtist(int id)
        {
            return _artists.FirstOrDefault(a => a.Id == id);
        }

    }
}
