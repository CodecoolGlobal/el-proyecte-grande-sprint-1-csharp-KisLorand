using Badcamp.Models;
using Badcamp.Services.Interfaces;

namespace Badcamp.Services
{
    public class SongStorage: ISongStorage
    {
        private List<Song> _storage;

        public SongStorage()
        {
            _storage = CreateTestSongStorage(100);
        }
        private List<Song> CreateTestSongStorage(int size)
        {
            _storage = new List<Song>();
            for (int i = 0; i < size; i++)
            {
                Song newSong = new Song();
                _storage.Add(newSong);
            }
            return _storage;
        }

        public List<Song> GetAllSongs()
        {
            return _storage;
        }
        public Song GetSong(Guid songID)
        {
            foreach (var song in _storage)
            {
                if(song.SongID == songID)
                {
                    return song;
                }
            }
            return null;
        }

        public void DeleteSong(Guid songID)
        {
            foreach (var song in _storage)
            {
                if (song.SongID == songID)
                {
                    _storage.Remove(song);
                    break;
                }
            }
        }
        public void UpdateSong(Song song)
        {
            foreach (var currentSong in _storage)
            {
                if (currentSong.SongID == song.SongID)
                {
                    song.UpdateSong(song);
                }
            }
        }
    }
}
