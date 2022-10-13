import React, { useState } from "react";
import "./artistCard.css";
import Button from "react-bootstrap/Button";
import Card from "react-bootstrap/Card";
import Collapse from "react-bootstrap/Collapse";
import { Link } from "react-router-dom";

const ArtistCard = ({ artist, descLength }) => {
  const cardStyle = {
    width: "16rem",
    margin: "2rem 1rem", 
    display: "inline-block" 
  };
  const [isOpen, setIsOpen] = useState(false);
  return (
    <Card className="artistCard" style={cardStyle} data-id={artist.id}>
      <Card.Body
        onClick={() => setIsOpen(!isOpen)}
        aria-controls="example-collapse-text"
        aria-expanded={isOpen}
      >
        <Card.Title>{artist.name}</Card.Title>
        <Collapse in={isOpen}>
          <div id="example-collapse-text">
            <Card.Text>
              <strong>Genres:</strong>
              {artist.genres.map((genre) => (
                <span key={genre}> {genre} </span>
              ))}
            </Card.Text>
            <Card.Text>
              {descLength < 20
                ? artist.description
                : artist.description.substring(0, 20) + "..."}
            </Card.Text>
            <Button variant="primary">
              <Link to={`/artistpage/${artist.id}`}>more info</Link>
            </Button>
          </div>
          </Collapse>
        
      </Card.Body>
    </Card>
  );
};

export default ArtistCard;
