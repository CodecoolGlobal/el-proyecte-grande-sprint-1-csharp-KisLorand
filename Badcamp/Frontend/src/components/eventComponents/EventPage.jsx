import React from 'react';
import Event from './Event';
import { useState, useEffect, useContext } from 'react';
import apiRequest from '../../requests/apiRequest';



const EventPage = (props) => {
    const [events, setEvents] = useState(null)
    const [artist, setArtist] = useState(null); 
    const url1 = "http://localhost:3500/event";
    const url2 = "http://localhost:3500/artist";
    useEffect(() => {
        apiRequest(url1, [events, setEvents]);
      }, [props.artistId]);
      useEffect(() => {
        apiRequest(url2, [artist, setArtist]);
      }, [props.artistId]);

  return (
    events === null ? 
    <p>"Loading..."</p> : 
    <div>
      
        {events.map((item) => {
            return(
                <Event 
                    key={item.id}
                    item={item}/>
            )
        })}
      
    </div>
  )
}

export default EventPage
