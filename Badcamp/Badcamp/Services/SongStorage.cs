using Badcamp.Models;
using Badcamp.Services.Interfaces;

namespace Badcamp.Services
{
    public class SongStorage: ISongStorage
    {
        private List<Song> _storage;

        public SongStorage()
        {
            _storage = CreateTestSongStorage(100, GetSongTitles());
        }
        private List<Song> CreateTestSongStorage(int size, List<string> title)
        {
            Random random = new Random();
            _storage = new List<Song>();
            for (int i = 0; i < size; i++)
            {
                var CurrentTitle = title[random.Next(0, title.Count)];
                Song newSong = new Song(CurrentTitle);
                _storage.Add(newSong);
            }
            return _storage;
        }
        private List<string> GetSongTitles()
        {
            List<string> titles = System.IO.File.ReadAllLines(@"SongTitles.txt").ToList();
            return titles;
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

        public List<Song> DeleteSong(Song song)
        {
            _storage.Remove(song);
            return _storage;
        }
        public Song UpdateSong(Song song)
        {
            foreach (var currentSong in _storage)
            {
                if (currentSong.SongID == song.SongID)
                {
                    currentSong.UpdateSong(song);
                    return currentSong;
                }
            }
            return null;
        }
        public Song CreateSong(string title)
        {
            Song newSong = new Song(title);
            _storage.Add(newSong);
            return newSong;
        }
    }
}
