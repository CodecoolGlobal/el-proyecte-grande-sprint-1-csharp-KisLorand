import React from 'react'


const Event = ({item}) => {
  return (
        <div className="card-div">
                <h2 className="event-title">{item.title}</h2>
                <p className='event-disc'>{item.description}</p>
        </div>
  )
}

export default Event
