import React from "react";
import { useState, useEffect } from "react";
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
      }
    };
    getData();
  }, []);

  const SetFilteredGenres = (artists) => {
    const singleGenres = [];
    artists.map((artist) =>
      artist.genres.forEach((genre) => {
        if (!singleGenres.includes(genre)) singleGenres.push(genre);
      })
    );
    setGenres(singleGenres);
  };

  const filterArtist = (artist) => {
    return artist.name.toLowerCase().includes(searchValue.toLocaleLowerCase())
      ? true
      : false;
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
                  filterArtist(artist) && artist.genres.includes(filterValue)
              )
            : artists.filter((artist) => filterArtist(artist))
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
