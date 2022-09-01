using System.Reflection;
using Badcamp.Models;

namespace Badcamp.Services
{
    public class EventService
    {
        public List<Event> Storage;

        public EventService()
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

        public List<Event> GetEventByArtist(int artistId)
        {
            List<Event> eventsByArtist = new List<Event>();
            foreach (Event @event in Storage)
            {
                if (@event.ArtistId == artistId)
                {
                    eventsByArtist.Add(@event);
                }
            }
            return eventsByArtist;
        }

        public List<Event> DeleteEvent(int eventId)
        {
            int artistId = 0;
            foreach (Event @event in Storage)
            {
                if (@event.Id == eventId)
                {
                    artistId = @event.ArtistId;
                    Storage.Remove(@event);
                }
            }

            return GetEventByArtist(artistId);
        }
    }
}
