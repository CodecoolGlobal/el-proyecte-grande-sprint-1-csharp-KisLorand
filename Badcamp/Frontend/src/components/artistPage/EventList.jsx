import React from 'react'
import Event from '../eventComponents/Event'

const EventList = ({events, artistName}) => {
  console.log(events);
  return (
    <ul>
        {events.map((item, index) => <Event key={index} item={item} artistName={artistName}/>)}
    </ul>
  )
}

export default EventList