import React from 'react'


const SongCard = ({ song }) => {
    return (
        <div className="card-div">
            <h2 className="song-title">{song.title}</h2>
            <p className='song-artist'>{song.artist}</p>
            <p className='song-album'>{song.album}</p>
            <p className='song-releaseDate'>{song.releaseDate}</p>
        </div>
    )
}

export default SongCard