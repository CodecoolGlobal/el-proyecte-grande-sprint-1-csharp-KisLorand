using System.Reflection;
using Badcamp.Domain.Entities;
using Badcamp.Models;

namespace Badcamp.Services
{
    public class EventService
    {
        //public List<Event> Storage;

        /*  public EventService()
          {
              Storage = new List<Event>();
              Event newEvent = new Event(0, 0, "Concert", "Let's meet there!!", 70);
              Event newEvent2 = new Event(1, 2, "Kázmér is giving free hugs", "Let's meet there!!", 200);
              Storage.Add(newEvent);
              Storage.Add(newEvent2);
          }
          public IReadOnlyList<Event> GetAllEvents()
          {
              return Storage.AsReadOnly();
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

          public IReadOnlyList<Event> GetEventByArtist(int artistId)
          {
              List<Event> eventsByArtist = new List<Event>();
              foreach (Event @event in Storage)
              {
                  if (@event.ArtistId == artistId)
                  {
                      eventsByArtist.Add(@event);
                  }
              }
              return eventsByArtist.AsReadOnly();
          }

          public void DeleteEvent(int eventId)
          {

              for (int i=0; i<=Storage.Count; i++)
              {
                  if (Storage[i].Id == eventId)
                  {
                  Storage.Remove(Storage[i]);
                      break;
                  }
              }
          }

          public Event UpdateEvent(int eventId, Event eventUpdate)
          {
              Event updatedEvent = new Event();
              foreach(Event @event in Storage)
              {
                  if (@event.Id == eventId)
                  {
                      @event.Title = eventUpdate.Title;
                      @event.Description = eventUpdate.Description;
                      updatedEvent = @event;
                  }
              }
              return updatedEvent;
          }*/
    }
}
