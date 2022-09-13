import React from 'react'
import { useState } from 'react'
import Event from './Event'

const [items, setItems] = useState([
    {
    "id": 0,
    "artistId": 0,
    "title": "new Song",
    "discription": "Hey! I released a new song!! Check it out "
    },
    {
    "id": 1,
    "artistId": 0,
    "title": "Concert",
    "discription": "Come listen to us on Friday! see you there!"
    }
    ])

const EventPage = () => {
  return (
    <div>
      <ul>
        {items.map((item) => {
            return(
                <Event 
                    key={item.id}
                    item={item}/>
            )
        })}
      </ul>
    </div>
  )
}

export default EventPage
