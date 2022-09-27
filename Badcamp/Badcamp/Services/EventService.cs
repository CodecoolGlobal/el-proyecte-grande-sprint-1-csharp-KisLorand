﻿using System.Reflection;
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

        public List<Event> DeleteEvent(int artistId, int eventId)
        {
            
            for (int i=0; i<=Storage.Count; i++)
            {
                if (Storage[i].Id == eventId)
                {
                Storage.Remove(Storage[i]);
                    break;
                }
            }

            return GetEventByArtist(artistId);
        }

        internal List<Event> UpdateEvent(int artistId, int eventId, Event eventUpdate)
        {
            foreach(Event @event in Storage)
            {
                if(@event.Id == eventId)
                {
                    @event.Title = eventUpdate.Title;
                    @event.Description = eventUpdate.Description;
                }
            }
            return GetEventByArtist(artistId);
        }
    }
}