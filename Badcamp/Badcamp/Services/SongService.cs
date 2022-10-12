using Badcamp.Domain.Entities;
using Badcamp.Models;
using System.Linq;
using Badcamp.Application;

namespace Badcamp.Services
{
    public class SongService : ISongService
    {
        private IBadcampContext _context;

        public SongService(IBadcampContext context)
        {
            _context = context;
        }


        public Song? GetSongById(int id)
        {
            var song = _context.Songs.FirstOrDefault(s => s.Id == id);
            return song;
        }
        public IReadOnlyList<Song> GetAllSongs()
        {
            return _context.Songs.ToArray();
        }

        public IReadOnlyList<Song> GetMultipleSongsByArtistId(Artist artist)
        {
            var songs = _context.Songs.Where(song => song.Artist == artist);
            return (IReadOnlyList<Song>)songs;
        }

        public IReadOnlyList<Song> GetMultipleSongsByAlbumId(int albumId)
        {
            // This one requires playlists to be implemented.
            throw new NotImplementedException();
        }

        public IReadOnlyList<Song> GetMultipleSongsByTitle(string title)
        {
            var songs = _context.Songs.Where(song => song.Title == title);
            return (IReadOnlyList<Song>)songs;
        }

        public IReadOnlyList<Song> GetMultipleSongsByGenreInclusive(IEnumerable<Genre> genres)
        {
            // TODO: think on this.
            // return SongStorage.FindAll(song => song.Genres.Contains(genres));
            throw new NotImplementedException();
        }

        public IReadOnlyList<Song> GetMultipleSongsByGenreExclusive(IEnumerable<Genre> genres)
        {
            var songs = _context.Songs.Where(song => song.Genres == genres);
            return (IReadOnlyList<Song>)songs;
        }

        public IReadOnlyList<Song> GetMultipleSongsByLyrics(string lyircs)
        {
            // Leaving it here for now as a reminder, but it's probably outside of scope.
            throw new NotImplementedException();
        }

        public void AddSong(Song newSong)
        {
            _context.Songs.Add(newSong);
            _context.SaveChanges();
        }

        public void UpdateSong(Song updateData)
        {
            _context.Songs.Update(updateData);
            _context.SaveChanges();
        }

        public void DeleteSong(Song song)
        {
            _context.Songs.Remove(song);
            _context.SaveChanges();
        }
    }
}
