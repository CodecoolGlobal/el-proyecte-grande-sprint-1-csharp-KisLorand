using System.Text.Json.Serialization;

namespace Badcamp.Models
{
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum Genre
	{
		Pop,
		Rock,
		Rap,
		Techno
	}
}