namespace Badcamp.Models
{
	public class ArtistModel
	{
		public int Id { get; set; }
		public string Name { get; set; } = String.Empty; 
		public int UserId { get; set; }
		public string Description { get; set; } = String.Empty;
		public string ProfilePicture { get; set; } = String.Empty;
        public Genre ArtistGenre { get; set; }
	}
}
