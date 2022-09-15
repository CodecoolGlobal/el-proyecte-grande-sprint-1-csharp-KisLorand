import React from 'react';
import { useState, useEffect, useContext } from 'react';
import ArtistName from './ArtistName';
import ArtistDescription from './ArtistDescription';
import apiRequest from '../../requests/apiRequest';
import { RequestContext } from '../../requests/requestContext';

const ArtistPage = (props) => {
  const [artist, setArtist] = useState(null); 
  const url = "http://localhost:3000/artist";
  useEffect(() => {
    apiRequest(url, [artist, setArtist]);
  }, [props.artistId]);
  //const {asd, setAsd} = useContext(RequestContext);
  return (
    artist === null ? 
    <p>"Loading..."</p> : 
    <div>
        <ArtistName artistName={artist[0].name}  />
        <ArtistDescription artistDesc={artist[0].description}/>
    </div>
  )
};

export default ArtistPage;
