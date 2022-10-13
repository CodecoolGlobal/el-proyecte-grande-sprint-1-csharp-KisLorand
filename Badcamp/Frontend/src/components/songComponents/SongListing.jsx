import React from 'react'
import { useState, useEffect, useContext } from 'react';
import SongContainer from './SongContainer';
import apiRequest from '../../requests/apiRequest';

const SongListing = (props) => {
    const [searchValue, setSearchValue] = useState("");
    const [songs, setSongs] = useState(null)
    const [artist, setArtists] = useState(null);
    const url1 = process.env.REACT_APP_BASE_URL + "api/songs";
    const url2 = process.env.REACT_APP_BASE_URL + "api/artists";
    useEffect(() => {
        apiRequest(url1, [songs, setSongs]);
        apiRequest(url2, [artist, setArtists]);
    },[props.songId]);

    return (
        (songs === null) ? <p> Loading... </p> :
        <div>
            <SongContainer
                songs={songs.filter((song) =>
                    song.title.toLowerCase().includes(searchValue.toLocaleLowerCase())
                )}
                artists={setArtists}
                setSongs={setSongs}
                searchValue={searchValue}
                setSearchValue={setSearchValue}
            />
        </div>
    );
};

export default SongListing
