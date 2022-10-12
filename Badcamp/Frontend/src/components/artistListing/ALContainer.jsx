import React, { useState , useEffect} from "react";
import ArtistCard from "./ArtistCard";
import InputContainer from "./input/InputContainer";

const ALContainer = ({
  artists,
  searchValue,
  setSearchValue,
  filterValue,
  setFilterValue,
  genres
}) => {


  
 

  return (
    <main className="container">
      <InputContainer
        searchValue={searchValue}
        setSearchValue={setSearchValue}
        filterValue={filterValue}
        setFilterValue={setFilterValue}
        genres={genres}

      />
       <section className="card-container"> 
      {artists.map((artist) => (
        <ArtistCard
          artist={artist}
          key={artist.id}
          descLength={artist.description.length}
        />
      ))}
       </section> 
    </main>
  );
};

export default ALContainer;
