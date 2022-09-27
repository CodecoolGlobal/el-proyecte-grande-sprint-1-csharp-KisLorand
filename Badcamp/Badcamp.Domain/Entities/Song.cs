namespace Badcamp.Models
{
    public class Song
    {
        public int Id { get; private set; }
        public int ArtistId { get; private set; }
        public string Title { get; private set; } = String.Empty;
        public string AlbumTitle { get; private set; } = String.Empty;
        public string Description { get; private set; } = String.Empty;
        public string Lyrics { get; private set; } = String.Empty;
        public string AudioSource { get; private set; } = String.Empty;
        public IEnumerable<Genre> Genres { get; private set; }
        public Song(int id, int artistId, string title, string album, string description, string lyrics, string audiosource, IEnumerable<Genre> genres)
        {   
            Id = id;
            ArtistId = artistId;
            Title = title;
            AlbumTitle = album;
            Description = description;
            Lyrics = lyrics;
            AudioSource = audiosource;
            Genres = genres;
        }
        public void SetId(int newId)
        {
            Id = newId;
        }

        public void UpdateSong(Song song)
        {
            if (ArtistId != song.ArtistId)
            {
                ArtistId = song.ArtistId;
            }
            if (Title != song.Title)
            {
                Title = song.Title;
            }
            if (AlbumTitle != song.AlbumTitle)
            {
                AlbumTitle = song.AlbumTitle;
            }
            if (Description != song.Description)
            {
                Description = song.Description;
            }
            if (Lyrics != song.Lyrics)
            {
                Lyrics = song.Lyrics;
            }
            if (AlbumTitle != song.AlbumTitle)
            {
                AlbumTitle = song.AlbumTitle;
            }
            if (Genres != song.Genres)
            {
                Genres = song.Genres;
            }
        }
    }
}