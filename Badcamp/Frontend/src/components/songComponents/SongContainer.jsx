import React, {useState} from "react";
import SongCard from "./SongCard";
import SongSearch from "./SongSearch.jsx";



const SongContainer = ({ songs, setSongs, artists, searchValue, setSearchValue }) => {

    return (
        <main className="container">
            <SongSearch
                searchValue={searchValue}
                setSearchValue={setSearchValue}
            />
            {songs.map((song) =>
            (
            <SongCard
                song={song}
                key={song.id}
            />
            ))}
        </main>
    );
};

export default SongContainer;