import React from 'react'
import { useState, useEffect, useContext } from 'react';
import SongContainer from './SongContainer';
import apiRequest from '../../requests/apiRequest';

const SongListing = (props) => {
    const [searchValue, setSearchValue] = useState("");
    const [songs, setSongs] = useState(null)
    const [artist, setArtists] = useState(null);
    const url1 = process.env.REACT_APP_BASE_URL + "api/Song/getall";
    //const url1 = "https://localhost:7151/api/Song/getall";
    useEffect(() => {
        apiRequest(url1, [songs, setSongs]);
    }, []);

    const test = () => {
        console.log(songs)
    }

    return (
        { test() }
        (songs === null) ? <p> Loading Songs... </p> :
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
