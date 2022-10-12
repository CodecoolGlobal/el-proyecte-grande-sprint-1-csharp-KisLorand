import React from "react";
import { useState, useEffect } from "react";
import ALContainer from "./ALContainer";

const ArtistListing = () => {
  const baseUrl = process.env.REACT_APP_BASE_URL
  const artistsUrl = `${baseUrl}api/ArtistGallery`;
  const genresUrl = `${baseUrl}api/Genre`;
  const [searchValue, setSearchValue] = useState("");
  const [filterValue, setFilterValue] = useState("");
  const [artists, setArtist] = useState([]);
  const [genres, setGenres] = useState([]);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    const getArtists = async () => {
      const response = await fetch(artistsUrl);
      if (!response.ok) {
        throw Error("Error occoured. Reload the app");
      } else {
        const data = await response.json();
        setArtist(data);
        setIsLoading(false);
      }
    };
    const getGenres = async () =>{
      const response = await fetch(genresUrl);
      if (!response.ok) {
        throw Error("Error occoured. Reload the app");
      } else {
        const data = await response.json();
        setGenres(data);
        setIsLoading(false);
      }
    }
    getArtists();
    getGenres();
    
  }, []);
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
