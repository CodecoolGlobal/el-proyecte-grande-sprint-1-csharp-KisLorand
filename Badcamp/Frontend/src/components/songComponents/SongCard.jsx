import React from 'react';
import "./songCard.css";
import Card from 'react-bootstrap/Card';


const SongCard = ({ song }) => {
    const cardStyle = { width: "16rem", margin: "2rem 1rem", display: "inline-block" }
    const cardGrow = () => {
        const cards = document.querySelectorAll('.card');
    }

    return (
        <Card className="songCard" style={cardStyle} data-id={song.id}>
            <Card.Body className="card" onMouseOver={()=> cardGrow()}>
                <Card.Header>{song.artistName}</Card.Header>
                <Card.Title>{song.title}</Card.Title>
                <Card.Subtitle className="mb-2 text-muted">{song.albumName}</Card.Subtitle>
            </Card.Body>
        </Card>
    );
}

export default SongCard