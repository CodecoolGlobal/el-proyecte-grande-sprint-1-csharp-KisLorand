import React , {useState} from "react";
import ArtistCard from "./ArtistCard";
import SearchInput from "./SearchInput";



const ALContainer = ({ artists, setArtist, searchValue, setSearchValue }) => {

  return (
    <main className="conatiner">
    <SearchInput 
    searchValue={searchValue}
    setSearchValue={setSearchValue}
    />
    {artists.map((artist) => (
        <ArtistCard
            artist={artist}
            key={artist.id}
            descLength={artist.description.length}
        />
    ))}
    </main>
  );
};

export default ALContainer;
