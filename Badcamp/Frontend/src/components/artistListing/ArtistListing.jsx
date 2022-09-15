import React from "react";
import { useState, useEffect } from "react";
import apiRequest from "../../requests/apiRequest";
import ALContainer from "./ALContainer";

const ArtistListing = () => {
  const API_URL = "http://localhost:3000/artists";
  const [searchValue, setSearchValue] = useState("");
  const [filterValue, setFilterValue] = useState("");
  const [artists, setArtist] = useState([]);
  const [genres, setGenres] = useState([]);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    const getData = async () => {
      const response = await fetch(API_URL);
      if (!response.ok) {
        throw Error("Error occoured. Reload the app");
      } else {
        const data = await response.json();
        setArtist(data);
        SetFilteredGenres(data);
        setIsLoading(false);
        console.log(data);
        console.log(genres);
      }
    };
    getData();
  }, []);

  const SetFilteredGenres = (artists) => {
    const singleGenres = [];
    console.log(artists);
    artists.map((artist) =>
      artist.genres.forEach((genre) => {
        if (!singleGenres.includes(genre)) singleGenres.push(genre);
      })
    );
    setGenres(singleGenres);
  };

  return isLoading ? (
    <p>Loading...</p>
  ) : (
    <div>
      <ALContainer
        artists={
          filterValue !== ""
            ? artists.filter(
                (artist) =>
                  artist.name
                    .toLowerCase()
                    .includes(searchValue.toLocaleLowerCase()) &&
                  artist.genres.includes(filterValue)
              )
            : artists
        }
        setArtists={setArtist}
        searchValue={searchValue}
        setSearchValue={setSearchValue}
        filterValue={filterValue}
        setFilterValue={setFilterValue}
        genres={genres}
      />
    </div>
  );
};

export default ArtistListing;
