import React from "react";
import Event from "./Event";
import { useState, useEffect, useContext } from "react";
import apiRequest from "../../requests/apiRequest";

const EventPage = (props) => {
	const [events, setEvents] = useState(null);
	const [isUpdate, setIsUpdate] = useState(false);
	const urlGet = process.env.REACT_APP_BASE_URL + "api/Event/GetEvents";
	const urlUpdate = process.env.REACT_APP_BASE_URL + "api/Event/UpdateEvent";
	const user = JSON.parse(localStorage.getItem("user"));
	useEffect(() => {
		apiRequest(urlGet, [events, setEvents]);
	}, []);

	const updateItem = (item) => {
		let updatedItem = {
			id: item.id,
			title: item.title,
			description: item.description,
			upvote: item.upvote,
		};
		return updatedItem;
	};

	const handleUpvote = (item) => {
		if (user) {
			item.upvote += 1;
			let updatedItem = updateItem(item);
			const requestOptions = {
				method: "PUT",
				headers: { "Content-Type": "application/json" },
				body: JSON.stringify(updatedItem),
			};
			fetch(urlUpdate, requestOptions).then((response) => response.json());
			setIsUpdate(!isUpdate);
		}
	};

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
