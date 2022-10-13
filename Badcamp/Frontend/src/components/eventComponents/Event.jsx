import React from "react";
import Card from "react-bootstrap/Card";
import "./EventCard.css";
import { Link } from "react-router-dom";

const Event = ({ item, handleUpvote }) => {
	return (
		<Card className="eventCard border border-4 w-50" style={{ width: "18rem" }}>
			<Card.Header>
				<Card.Title>
					{item.title}
					<Card.Subtitle className="mb-2 text-muted text-end">
						<Link
							to={`/artistpage/${item.artist.id}`}
							style={{ textDecoration: "none" }}
							className="subtitle"
						>
							{item.artist.name}
						</Link>
					</Card.Subtitle>
				</Card.Title>
			</Card.Header>
			<Card.Body>
				<Card.Text>{item.description}</Card.Text>
				<div className="upVote">
					{item.upvote}{" "}
					<img
						src="/upvote-png.png"
						alt="image"
						className="upvote-img"
						onClick={() => handleUpvote(item)}
					/>
				</div>
			</Card.Body>
		</Card>
	);
};

export default Event;
