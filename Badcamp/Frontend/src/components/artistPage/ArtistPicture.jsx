import React from 'react';

const ArtistPicture = (props) => {
  return (
    <img src={
        require("./public/favicon.ico").default
    } alt="profile picture"
        height={props.height}>
    </img>
  )
};

export default ArtistPicture;