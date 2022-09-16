import React from 'react';
import { useState, useEffect, useContext } from 'react';
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
        <Card className="eventCard border border-4 w-50" style={{ width: "18rem" }}>
        <Card.Header>
          <Card.Title>
            <ArtistName artistName={artist[0].name}  />
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
