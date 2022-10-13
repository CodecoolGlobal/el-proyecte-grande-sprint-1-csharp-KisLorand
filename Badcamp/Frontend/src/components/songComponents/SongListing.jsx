import React from 'react';
import { useState, useEffect } from 'react';
import SongContainer from './SongContainer';
import apiRequest from '../../requests/apiRequest';

const SongListing = (props) => {
    const [searchValue, setSearchValue] = useState("");
    const [songs, setSongs] = useState(null)
    const getAll = process.env.REACT_APP_BASE_URL + "api/Song/getall";
    useEffect(() => {
        apiRequest(getAll, [songs, setSongs]);
    }, []);
    return (
        (songs === null) ? <p> Loading Songs... </p> :
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
