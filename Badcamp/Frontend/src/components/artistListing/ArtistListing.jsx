import React from "react";
import { useState } from "react";
import ALContainer from "./ALContainer";

const ArtistListing = () => {
  const [searchValue, setSearchValue] = useState("");
  const [artists, setArtist] = useState([
    {
      id: 0,
      userId: 0,
      name: "Zoli",
      description: "Nagyon ugyes vagyok köszönöm szépen ahh aha hahha...",
      profilePicture: "/path/placeholder/picture.png",
      genres: ["alter", "techno"],
    },
    {
      id: 1,
      userId: 0,
      name: "Laci",
      description: "Nagyon ugyes vagyok köszönöm szépen ahh aha hahha...",
      profilePicture: "/path/placeholder/picture.png",
      genres: ["pop", "rock", "r&b"],
    },
    {
      id: 2,
      userId: 0,
      name: "Zolesz",
      description: "Nagyon ugyes vagyok köszönöm szépen ahh aha hahha...",
      profilePicture: "/path/placeholder/picture.png",
      genres: ["alter", "techno"],
    },
    {
      id: 4,
      userId: 0,
      name: "Lacika",
      description: "Nagyon ugyes vagyok köszönöm szépen ahh aha hahha...",
      profilePicture: "/path/placeholder/picture.png",
      genres: ["pop", "rock", "r&b"],
    },
  ]);

  return (
    <div>
      <ALContainer
        artists={artists.filter((artist) =>
          artist.name.toLowerCase().includes(searchValue.toLocaleLowerCase())
        )}
        setArtists={setArtist}
        searchValue={searchValue}
        setSearchValue={setSearchValue}
      />
    </div>
  );
};

export default ArtistListing;
