import React from 'react'
import { useState } from 'react'
import Event from './Event'



const EventPage = () => {
    const [items, setItems] = useState([
        {
        "id": 0,
        "artistId": 0,
        "title": "new Song",
        "description": "Hey! I released a new song!! Check it out "
        },
        {
        "id": 1,
        "artistId": 0,
        "title": "Concert",
        "description": "Come listen to us on Friday! see you there!"
        }
        ])
  return (
    <div>
      
        {items.map((item) => {
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
