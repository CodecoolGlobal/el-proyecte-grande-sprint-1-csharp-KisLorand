namespace Badcamp.Models
{
    public class Song
    {
        private Guid _songID;
        private Guid _artistID;
        private string _title;
        private string _source;

        public Guid SongID => _songID;
        public Guid ArtistID => _artistID;
        public string Title => _title;
        public string Source => _source;
        public Song()
        {
            _songID = Guid.NewGuid();
            _artistID = Guid.NewGuid();
            _title = "1234";
            _source = "ghfdvjzck";
        }

        public void UpdateSong(Song song)
        {
            if (_title != song.Title)
            {
                _title = song.Title;
            }
            if (_source != song.Source)
            {
                _source = song.Source;
            }
        }
    }
}