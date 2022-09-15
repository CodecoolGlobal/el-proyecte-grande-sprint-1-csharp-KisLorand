import React from 'react'
import SongCard from '../songComponents/SongCard';

const SongList = ({songs}) => {
  return (
    <div>
        {songs.map((item, index) => <SongCard key={index} song={item}/>)}
    </div>

  )
}

export default SongList;