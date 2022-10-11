import React from "react";
import Event from "./Event";
import { useState, useEffect, useContext } from "react";
import apiRequest from "../../requests/apiRequest";

const EventPage = (props) => {
	const [events, setEvents] = useState(null);
	const urlGet = "https://localhost:7151/api/Event/GetEvents";
	const urlUpdate = "https://localhost:7151/api/Event/UpdateEvent";
	useEffect(() => {
		apiRequest(urlGet, [events, setEvents]);
	}, []);

	const handleUpvote = async (item) => {
		item.upvote += 1;
		let fd = new FormData();
		for (let prop in item) {
			fd.append(prop, JSON.stringify(item[prop]));
		}
		const requestOptions = {
			method: "PUT",
			headers: { "Content-Type": "application/json" },
			body: fd,
		};
		fetch(urlUpdate, requestOptions).then((response) => response.json());
	};

	console.log(events);
	return events === null ? (
		<p>"Loading..."</p>
	) : (
		<div>
			{events.map((item) => {
				return <Event key={item.id} item={item} handleUpvote={handleUpvote} />;
			})}
		</div>
	);
};

export default EventPage;
