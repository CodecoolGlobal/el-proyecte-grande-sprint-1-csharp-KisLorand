using Badcamp.Models;

namespace Badcamp.Services.Interfaces
{
    public interface ISongStorage
    {
        public Song GetSong(Guid songID);
        public List<Song> GetAllSongs();
    }
}