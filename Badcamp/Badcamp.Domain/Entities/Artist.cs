namespace Badcamp.Domain.Entities
{
	public class Artist
	{
		public long Id { get; set; }
		public string Name { get; set; } = String.Empty; 
		public User? User { get; set; }
		public string Description { get; set; } = String.Empty;
		public string ProfilePicture { get; set; } = String.Empty;
        public HashSet<Genre>? Genres { get; set; } = new HashSet<Genre>();
		public HashSet<Event>? Events { get; set; } = new HashSet<Event>();
		public HashSet<Song>? Songs { get; set; } = new HashSet<Song>();

        public Artist()
        {

        }

        public Artist(long id, string name, User user, string description, string profilePicture, HashSet<Genre> genres, HashSet<Event> events, HashSet<Song> songs)
        {
            Id = id;
            Name = name;
            User = user;
            Description = description;
            ProfilePicture = profilePicture;
            Genres = genres;
            Events = events;
            Songs = songs;
        }
    }
}
