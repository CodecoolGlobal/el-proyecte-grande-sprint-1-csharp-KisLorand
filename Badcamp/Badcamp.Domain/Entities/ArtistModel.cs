namespace Badcamp.Models
{
	public class ArtistModel
	{
		public long Id { get; set; }
		public string Name { get; set; } = String.Empty; 
		public User User { get; set; }
		public string Description { get; set; } = String.Empty;
		public string ProfilePicture { get; set; } = String.Empty;
        public HashSet<Genre> ArtistGenre { get; set; }
		public HashSet<Event> Events { get; set; }
		public HashSet<Song> Songs { get; set; }




	}
}
