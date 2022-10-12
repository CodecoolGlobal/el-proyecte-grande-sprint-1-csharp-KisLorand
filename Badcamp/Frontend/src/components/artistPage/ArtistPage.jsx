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

const ArtistPage = (props) => {
  const [artist, setArtist] = useState(null); 
  const [listData, setListData] = useState(null); 
  const [selectSong, setSelectSong] = useState(true);
  const editRef = useRef(false);

  const urlArtists = `${process.env.REACT_APP_BASE_URL}api/ArtistPage`; 
  const urlSongs = `${process.env.REACT_APP_BASE_URL}api/Event/GetEvents`; 
  const urlEvents = `${process.env.REACT_APP_BASE_URL}api/Event/GetEvents`; //

  useEffect(() => {
    console.log(urlArtists)
    apiRequest(urlArtists, [artist, setArtist]);
    apiRequest(urlSongs, [listData, setListData])
    console.log(artist);
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
        <Card className="eventCard border border-4 w-50" style={{ width: "18rem" }}>
        <Card.Header>
          <Card.Title>
            {/* editNameRef */}
            {
            editRef ?
              <Input
              role="input"
              aria-label="input for client's email"
                id="client-email"
                type="artistName"
                label="Enter client's email address*:"
                placeholder={artist[0].name}
              /> :
              <ArtistName artistName={artist[0].name}  />
            }
            <EditBtn ref={editRef} />
            <ArtistDescription artistDesc={artist[0].description}/>
            <Card.Subtitle className="mb-2 text-muted text-end">
              <ArtistPicture artistProfilePicture={artist[0].profilePicture} height={250} />
            </Card.Subtitle>
          </Card.Title>
        </Card.Header>
        <Card.Body>
            <ToggleButton toggle={[selectSong, setSelectSong]}/>
            {selectSong ? 
              <SongList 
                songs={listData.filter((song) => song.artistId === artist[0].id)} 
              /> :
              <EventList
                events={listData.filter((event) => event.artistId === artist[0].id)}
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
