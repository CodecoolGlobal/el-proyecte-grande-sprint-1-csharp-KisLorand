import React from "react";
import "./artistCard.css";
import Button from "react-bootstrap/Button";
import Card from "react-bootstrap/Card";

const ArtistCard = ({ artist, descLength }) => {
  const cardStyle = { width: "16rem", margin: "2rem 1rem", display: "inline-block" }
  const cardGrow = () =>{
    const cards = document.querySelectorAll('.card')
    console.log(cards)
  }
  return (
    <Card
      className="artistCard"
      style={cardStyle}

      data-id = {artist.id}
    >
      <Card.Body
      className="card"
             onMouseOver={() => cardGrow()} 
      >
        <Card.Title>{artist.name}</Card.Title>
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
        <Button variant="primary">more info</Button>
      </Card.Body>
    </Card>
  );
};

export default ArtistCard;
