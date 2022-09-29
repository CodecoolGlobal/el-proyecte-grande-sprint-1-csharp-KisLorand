using System.Text.Json.Serialization;

namespace Badcamp.Domain.Entities
{
	public class Genre
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public HashSet<Song> Songs { get; set; } = new HashSet<Song>();
		public HashSet<Artist> Artists { get; set; } = new HashSet<Artist>();
	}
}