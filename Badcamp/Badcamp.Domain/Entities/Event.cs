namespace Badcamp.Models
{
    public class Event
    {
        public long Id { get; set; }
        public ArtistModel Artist { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int Upvote { get; set; }

    }
}
