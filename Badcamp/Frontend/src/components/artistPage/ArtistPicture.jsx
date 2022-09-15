import React from 'react';

const ArtistPicture = (props) => {
  return (
    <img src={
        props.artistProfilePicture
    } alt="profile picture"
        height={props.height}>
    </img>
  )
};

export default ArtistPicture;