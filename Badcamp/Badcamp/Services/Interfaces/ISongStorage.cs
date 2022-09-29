using Badcamp.Domain.Entities;
using Badcamp.Models;

namespace Badcamp.Services.Interfaces
{
    public interface ISongStorage
    {
        public Song GetSong(Guid songID);
        public List<Song> GetAllSongs();
        public List<Song> DeleteSong(Song song);
        public Song UpdateSong(Song song);
        public Song CreateSong(string title);
    }
}