import React from 'react';
import { useState, useEffect, useContext } from 'react';
import ArtistName from './ArtistName';
import ArtistDescription from './ArtistDescription';
import ArtistPicture from './ArtistPicture';
import ItemList from './ItemList';
import ToggleButton from './ToggleButton';
import apiRequest from '../../requests/apiRequest';
import { RequestContext } from '../../requests/requestContext';

const ArtistPage = (props) => {
  const [artist, setArtist] = useState(null); 
  const [songs, setSongs] = useState(null); 
  const [selectSong, setSelectSong] = useState(true);

  const urlArtists = "http://localhost:3000/artist";
  const urlSongs = "http://localhost:3000/songs";
  const urlEvents = "http://localhost:3000/events";
  
  useEffect(() => {
    apiRequest(urlArtists, [artist, setArtist]);
    apiRequest(urlSongs, [songs, setSongs])
  }, [props.artistId]);

  useEffect(() => {
    const url = (selectSong ? urlSongs : urlEvents)
    apiRequest(url, [songs, setSongs]);
  }, [selectSong]);

  if (artist === null || songs == null) {
    return (
      <p>"Loading..."</p>
    );
  } else {
    return (
      <div>
        <ArtistName artistName={artist[0].name}  />
        <ArtistPicture artistProfilePicture={artist[0].profilePicture} height={250} />
        <ArtistDescription artistDesc={artist[0].description}/>
        <ToggleButton toggle={[selectSong, setSelectSong]}/>
        <ItemList items={songs} />
    </div>
    );
  };
};

export default ArtistPage;
