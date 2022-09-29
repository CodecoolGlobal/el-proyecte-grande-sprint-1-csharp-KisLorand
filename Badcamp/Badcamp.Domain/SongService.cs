using Badcamp.Domain.Entities;
using Badcamp.Models;
using System.Linq;

namespace Badcamp.Services
{
    public class SongService : ISongService
    {
        public List<Song> SongStorage;

        public SongService()
        {
            SongStorage = new List<Song>();
        }


        public Song GetSongById(int id)
        {
            var song = SongStorage.FirstOrDefault(s => s.Id == id);
            if (song == default)
            {
                throw new KeyNotFoundException(nameof(song));
            }
            return song;
        }
        public IReadOnlyList<Song> GetAllSongs()
        {
            return SongStorage.AsReadOnly();
        }

        public IReadOnlyList<Song> GetMultipleSongsByArtistId(int artistId)
        {
            throw new NotImplementedException();
            //return SongStorage.FindAll(song => song.ArtistId == artistId);
        }

        public IReadOnlyList<Song> GetMultipleSongsByAlbumId(int albumId)
        {
            // This one requires playlists to be implemented.
            throw new NotImplementedException();
        }

        public IReadOnlyList<Song> GetMultipleSongsByTitle(string title)
        {
            return SongStorage.FindAll(song => song.Title == title);
        }

        public IReadOnlyList<Song> GetMultipleSongsByGenreInclusive(IEnumerable<Genre> genres)
        {
            // TODO: think on this.
            // return SongStorage.FindAll(song => song.Genres.Contains(genres));
            throw new NotImplementedException();
        }

        public IReadOnlyList<Song> GetMultipleSongsByGenreExclusive(IEnumerable<Genre> genres)
        {
            return (IReadOnlyList<Song>)SongStorage.Where(song => song.Genres == genres);
        }

        public IReadOnlyList<Song> GetMultipleSongsByLyrics(string lyircs)
        {
            // Leaving it here for now as a reminder, but it's probably outside of scope.
            throw new NotImplementedException();
        }

        public Song AddSong(Song newSong)
        {
            throw new NotSupportedException();
            //int id = (SongStorage.Count is not 0) ? SongStorage.Last().Id + 1 : 0;
            //newSong.SetId(id);
            //SongStorage.Add(newSong);
        }

        public void UpdateSong(int songId, Song updateData)
        {
            var oldData = SongStorage.FirstOrDefault(song => song.Id == songId);
            if (oldData == default)
            {
                throw new KeyNotFoundException(nameof(songId));
            }
            oldData.UpdateSong(updateData);
        }

        public void DeleteSong(Song song)
        {
            SongStorage.Remove(song);
        }

        public void DeleteSong(int songId)
        {
            var song = GetSongById(songId);
            SongStorage.Remove(song);
        }
    }
}
