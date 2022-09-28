using System.Text.Json.Serialization;

namespace Badcamp.Models
{
	public class Genre
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public HashSet<Song> Songs { get; set; }
		public HashSet<ArtistModel> Artists { get; set; }
	}
}