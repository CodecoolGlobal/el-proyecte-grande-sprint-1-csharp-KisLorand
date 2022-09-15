import React from 'react'
import { useState } from 'react'
import SongContainer from './SongContainer';

const SongListing = () => {
    const [searchValue, setSearchValue] = useState("");
    const [songs, setSongs] = useState([
        {
            id: 0,
            artistId: 0,
            albumId: 0,
            albumName: "Walking with Strangers",
            artistName: "Birthday Massacre",
            title: "Red Stars",
            releaseDate: "2007",
            description: "Red Stars by Birthday Massacre",
            lyrics: "It's my red star (steal it) It's my red star (cant let go) It's my red star (conceal it) It's my red star Oh, no"
        },
        {
            id: 1,
            artistId: 0,
            albumId: 0,
            albumName: "Walking with Strangers",
            artistName: "Birthday Massacre",
            title: "Looking Glass",
            releaseDate: "2007",
            description: "Looking Glass by Birthday Massacre",
            lyrics: "It's a glass cage so I can't pretend You hide beneath the physical I see it coming but I can't defend You cut so deep, my belief is gone My belief is gone, my belief is"
        }
    ]);

    return (
        <div>
            <SongContainer
                songs={songs.filter((song) =>
                    song.title.toLowerCase().includes(searchValue.toLocaleLowerCase())
                )}
                setSongs={setSongs}
                searchValue={searchValue}
                setSearchValue={setSearchValue}
            />
        </div>
    );
};

export default SongListing
