namespace Badcamp.Models
{
    public class Event
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Event(int id, int artistId, string title, string description)
        {
            Id = id;
            ArtistId = artistId;
            Title = title;
            Description = description;

        }
    }
}
