import React from 'react'
import Card from 'react-bootstrap/Card';



const Event = ({item}) => {
  return (
    <Card style={{ width: '18rem' }}>
    <Card.Body>
      <Card.Title>{item.title}</Card.Title>
      <Card.Subtitle className="mb-2 text-muted">{item.artistId}</Card.Subtitle>
      <Card.Text>
        {item.description}
      </Card.Text>
    </Card.Body>
  </Card>
);
}

export default Event
