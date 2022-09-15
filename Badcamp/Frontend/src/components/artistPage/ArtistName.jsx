import React from 'react';
import { useContext } from 'react';
import { RequestContext } from '../../requests/requestContext';

const ArtistName = (props) => {
    
  return (
    <div>
      {props.artistName}
    </div>
  )
};

export default ArtistName;
