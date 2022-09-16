import React from 'react';
import { useContext } from 'react';
import { RequestContext } from '../../requests/requestContext';

const ArtistName = (props) => {
    
  return (
    <div>
      <h2>{props.artistName}</h2>
    </div>
  )
};

export default ArtistName;
