import React from 'react';
import { useState, useEffect, useRef, useContext } from 'react';
import ArtistName from './ArtistName';
import ArtistDescription from './ArtistDescription';
import ArtistPicture from './ArtistPicture';
import SongList from './SongList';
import ToggleButton from './ToggleButton';
import Event from '../eventComponents/Event';
import apiRequest from '../../requests/apiRequest';
import { RequestContext } from '../../requests/requestContext';
import EventList from './EventList';
import Card from "react-bootstrap/Card";
import Input from './Input';
import EditBtn from './EditBtn';

import InputTextarea from './InputTextarea';

const ArtistPage = (props) => {
  const [artist, setArtist] = useState(null); 
  const [listData, setListData] = useState(null); 
  const [selectSong, setSelectSong] = useState(true);
  const [editName, setEditName] = useState(false);
  const [editState, setEditState] = useState(false);

  const urlArtists = `${process.env.REACT_APP_BASE_URL}api/ArtistPage`; 
  //const urlSongs = `${process.env.REACT_APP_BASE_URL}api/Song/getall`; 
  const urlSongs = `${process.env.REACT_APP_BASE_URL}api/Event/GetEvents`; 
  const urlEvents = `${process.env.REACT_APP_BASE_URL}api/Event/GetEvents`; 

  useEffect(() => {
    apiRequest(urlArtists, [artist, setArtist]);
    apiRequest(urlSongs, [listData, setListData]);
  }, [props.artistId]);

  useEffect(() => {
    const url = (selectSong ? urlSongs : urlEvents)
    apiRequest(url, [listData, setListData]);
    console.log(listData);
  }, [selectSong]);

  useEffect(()=>{
    apiRequest(urlArtists, [artist, setArtist]);
    apiRequest(urlSongs, [listData, setListData]);
  },[editState]);

  const HandleValueChange = (value) => {
    console.log(value)
  }

  if (artist === null || listData == null) {
    return (
      <p>"Loading..."</p>
    );
  } else {
    return (
      <div>
        <Card className="eventCard border border-4 w-50" style={{ width: "18rem" }}>
        <Card.Header>
          <Card.Title>
          <EditBtn 
            toggle={ [editName, setEditName] } 
            pfp={artist[0].profilePicture} 
            artist={artist[0]} 
            edit={[editState, setEditState] }
          />

            {
            editName === true ?
              <form>
              <Input
                role="input"
                aria-label="input for artist's name"
                id="artist-name-edit"
                type="artistName"
                placeholder={artist[0].name}
/*                 value={artist[0].name}
                onChange={(e) => {HandleValueChange(e.target.value)}} */
              /> 
              <InputTextarea 
                id="artist-description-textarea"
                aria-label="input for artist's description"
                placeholder={artist[0].description}
              />
              </form > : <>
              <ArtistName artistName={artist[0].name}  />
              <ArtistDescription artistDesc={artist[0].description}/>
              </>
            }
            
            <Card.Subtitle className="mb-2 text-muted text-end">
              <ArtistPicture artistProfilePicture={artist[0].profilePicture} height={250} />
            </Card.Subtitle>
          </Card.Title>
        </Card.Header>
        <Card.Body>
            <ToggleButton toggle={[selectSong, setSelectSong]}/>
            {selectSong ? 
              <SongList 
                songs={listData.filter((song) => song.artist.id === artist[0].id)} 
              /> :
              <EventList
                events={listData.filter((event) => event.artist.id === artist[0].id)}
                artistName={artist[0].name}
              />
            }
        </Card.Body>
      </Card>
    </div>
    );
  };
};

export default ArtistPage;
