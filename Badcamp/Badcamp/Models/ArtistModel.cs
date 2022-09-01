namespace Badcamp.Models
{
	public class ArtistModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int UserId { get; set; }
		public string Description { get; set; }
		public string ProfilePicture { get; set; }

		public Genre ArtistGenre { get; set; }
	}
}
