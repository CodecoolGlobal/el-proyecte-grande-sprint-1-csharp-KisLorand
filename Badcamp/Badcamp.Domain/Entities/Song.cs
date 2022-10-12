namespace Badcamp.Domain.Entities
{
    public class Song
    {
        public long Id { get; set; }
        public Artist Artist { get; set; }
        public string Title { get; set; } = String.Empty;
        public string AlbumTitle { get;  set; } = String.Empty;
        public string Description { get;  set; } = String.Empty;
        public string Lyrics { get; set; } = String.Empty;
        public string AudioSource { get; set; } = String.Empty;
        public HashSet<Genre> Genres { get; set; } = new HashSet<Genre>();

        public Song(long id, Artist artist, string title, string albumTitle, string description, string lyrics, string audioSource, HashSet<Genre> genres)
        {
            Id = id;
            Artist = artist;
            Title = title;
            AlbumTitle = albumTitle;
            Description = description;
            Lyrics = lyrics;
            AudioSource = audioSource;
            Genres = genres;
        }

        public Song()
        {
        }

        public void SetId(int newId)
        {
            Id = newId;
        }

        public void UpdateSong(Song song)
        {
            
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