namespace Badcamp.Domain.Entities
{
    public class Event
    {
        public long Id { get; set; }
        public Artist Artist { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int Upvote { get; set; }

    }
}
