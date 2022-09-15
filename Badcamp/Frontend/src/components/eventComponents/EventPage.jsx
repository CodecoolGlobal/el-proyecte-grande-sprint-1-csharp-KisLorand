import React from 'react';
import Event from './Event';
import { useState, useEffect, useContext } from 'react';
import apiRequest from '../../requests/apiRequest';



const EventPage = (props) => {
    const [events, setEvents] = useState(null)
    const [artist, setArtist] = useState(null); 
    const url1 = "http://localhost:3000/events";
    const url2 = "http://localhost:3000/artists";
    useEffect(() => {
        apiRequest(url1, [events, setEvents]);
        apiRequest(url2, [artist, setArtist]);
      }, [props.eventId, props.artistId]);
  return (
    (events === null || artist === null) ? 
    <p>"Loading..."</p> : 
    <div>
        {events.map((item) => {
                return(
                    <Event 
                        key={item.id}
                        item={item}
                        artistName ={artist.map((artist) => {return(artist.artistId === item.artistId ? artist.artistName : "")})}

                        />
                        
        )})}
            
      
    </div>
  )
}

export default EventPage
