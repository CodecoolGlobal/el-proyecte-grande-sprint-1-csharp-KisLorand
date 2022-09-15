import React from "react";
import Card from "react-bootstrap/Card";
import "./EventCard.css";
import { Link } from "react-router-dom";

const Event = ({ item, artistName }) => {
  return (
    <Card className="eventCard border border-4 w-50" style={{ width: "18rem" }}>
      <Card.Header>
        <Card.Title>
          {item.title}
          <Card.Subtitle className="mb-2 text-muted text-end">
            <Link to="/artistpage" style={{ textDecoration: "none" }}>
              {artistName}
            </Link>
          </Card.Subtitle>
        </Card.Title>
      </Card.Header>
      <Card.Body>
        <Card.Text>{item.description}</Card.Text>
        <div className="upVote">
          {item.upVote}{" "}
          <img src="/upvote-png.png" alt="image" className="upVote-img" />
        </div>
      </Card.Body>
    </Card>
  );
};

export default Event;
