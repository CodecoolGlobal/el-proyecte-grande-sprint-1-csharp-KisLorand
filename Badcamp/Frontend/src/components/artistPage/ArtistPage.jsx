import React from 'react';
import { useState, useEffect, useContext } from 'react';
import ArtistName from './ArtistName';
import ArtistDescription from './ArtistDescription';
import ArtistPicture from './ArtistPicture';
import ItemList from './ItemList';
import ToggleButton from './ToggleButton';
import Event from '../eventComponents/Event';
import apiRequest from '../../requests/apiRequest';
import { RequestContext } from '../../requests/requestContext';

const ArtistPage = (props) => {
  const [artist, setArtist] = useState(null); 
  const [listData, setListData] = useState(null); 
  const [selectSong, setSelectSong] = useState(true);

  const urlArtists = "http://localhost:3000/artists";
  const urlSongs = "http://localhost:3000/songs";
  const urlEvents = "http://localhost:3000/events";
  
  useEffect(() => {
    apiRequest(urlArtists, [artist, setArtist]);
    apiRequest(urlSongs, [listData, setListData])
  }, [props.artistId]);

  useEffect(() => {
    const url = (selectSong ? urlSongs : urlEvents)
    apiRequest(url, [listData, setListData]);
  }, [selectSong]);

  if (artist === null || listData == null) {
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
        <ItemList items={
          selectSong ? listData : (listData.map((data) => (<Event item={data} />)))
          } />
    </div>
    );
  };
};

export default ArtistPage;
