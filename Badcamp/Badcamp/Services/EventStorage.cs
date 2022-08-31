using System.Reflection;
using Badcamp.Models;

namespace Badcamp.Services
{
    public class EventStorage
    {
        public List<Event> Storage;

        public EventStorage()
        {
            Storage = new List<Event>();
            Event newEvent = new Event(0, 0, "Concert", "Let's meet there!!");
            Storage.Add(newEvent);
        }

        public Event CreateEvent(int artistId, Event newEvent)
        {
            int id = 0;
            if (Storage.Count > 0)
            {
                id = Storage.Last().Id +1;
            }
            newEvent.Id = id;
            newEvent.ArtistId = artistId;

            
            Storage.Add(newEvent);
            return newEvent;
        }
    }
}
