import React from 'react'
import Card from 'react-bootstrap/Card';


const SongCard = ({ song }) => {
    return (
        <Card style={{ width: '18rem' }}>
            <Card.Body>
                <Card.Header>{song.artistName}</Card.Header>
                <Card.Title>{song.title}</Card.Title>
                <Card.Subtitle className="mb-2 text-muted">{song.albumName}</Card.Subtitle>
            </Card.Body>
        </Card>
    );
}

export default SongCard