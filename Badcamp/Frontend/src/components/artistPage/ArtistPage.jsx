import React from 'react';
import { useState, useEffect, useRef, useContext } from 'react';
import { useParams } from 'react-router-dom';
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
  const { id } = useParams();
  const user = JSON.parse(localStorage.getItem('user'));
  const [artist, setArtist] = useState(null); 
  const [listData, setListData] = useState(null); 
  const [selectSong, setSelectSong] = useState(true);
  const [editName, setEditName] = useState(false);
  const [editState, setEditState] = useState(false);

  const urlArtists = `${process.env.REACT_APP_BASE_URL}api/ArtistPage/${id}`; 
  const urlArtistEdit = `${process.env.REACT_APP_BASE_URL}api/ArtistPage/Edit/${user.userId}`; 
  const urlSongs = `${process.env.REACT_APP_BASE_URL}api/Song/getall`; 
  const urlEvents = `${process.env.REACT_APP_BASE_URL}api/Event/GetEvents`; 

  useEffect(() => {
    apiRequest(urlArtistEdit, [artist, setArtist]);
    apiRequest(urlSongs, [listData, setListData]);
  }, [id===null])

  useEffect(() => {
    apiRequest(urlArtists, [artist, setArtist]);
    apiRequest(urlSongs, [listData, setListData]);
  }, [id===undefined]);

  useEffect(() => {
    const url = (selectSong ? urlSongs : urlEvents)
    apiRequest(url, [listData, setListData]);
    apiRequest(urlSongs, [listData, setListData]);
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
            {user.userId == artist.user.id ? 
              <EditBtn 
                toggle={ [editName, setEditName] } 
                pfp={artist.profilePicture} 
                artist={artist} 
                edit={[editState, setEditState] }
              /> : null
            }

            {
            editName === true ?
              <form>
              <Input
                role="input"
                aria-label="input for artist's name"
                id="artist-name-edit"
                type="artistName"
                placeholder={artist.name}
              /> 
              <InputTextarea 
                id="artist-description-textarea"
                aria-label="input for artist's description"
                placeholder={artist.description}
              />
              </form > : <>
              <ArtistName artistName={artist.name}  />
              <ArtistDescription artistDesc={artist.description}/>
              </>
            }
            
            <Card.Subtitle className="mb-2 text-muted text-end">
              <ArtistPicture artistProfilePicture={artist.profilePicture} height={250} />
            </Card.Subtitle>
          </Card.Title>
        </Card.Header>
        <Card.Body>
            <ToggleButton toggle={[selectSong, setSelectSong]}/>
            {selectSong ? 
              <SongList 
                songs={listData.filter((song) => song.artistId === artist.id)} 
              /> :
              <EventList
                events={listData.filter((event) => event.artistId === artist.id)}
                artistName={artist.name}
              />
            }
        </Card.Body>
      </Card>
    </div>
    );
  };
};

export default ArtistPage;
