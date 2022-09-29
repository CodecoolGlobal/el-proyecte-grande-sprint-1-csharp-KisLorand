using Badcamp.Domain.Entities;
using Badcamp.Models;

namespace Badcamp.Services
{
    public interface ISongService
    {
        public Song GetSongById(int id);
        public IReadOnlyList<Song> GetAllSongs();
        public IReadOnlyList<Song> GetMultipleSongsByArtistId(int artistId);
        public IReadOnlyList<Song> GetMultipleSongsByAlbumId(int albumId);
        public IReadOnlyList<Song> GetMultipleSongsByTitle(string title);
        public IReadOnlyList<Song> GetMultipleSongsByGenreInclusive(IEnumerable<Genre> genres);
        public IReadOnlyList<Song> GetMultipleSongsByGenreExclusive(IEnumerable<Genre> genres);
        public IReadOnlyList<Song> GetMultipleSongsByLyrics(string lyircs);
        public Song AddSong(Song song);
        public void UpdateSong(int songId, Song updateData);
        public void DeleteSong(Song song);
        public void DeleteSong(int songId);

    }
}