import React from 'react'
import { useState } from 'react'
import SongCard from './SongCard'



const SongListing = () => {
    const [songs, setSongs] = useState([
        {
            "id": 0,
            "artistId": 0,
            "albumId": 0,
            "albumName": "Walking with Strangers",
            "artistName": "Birthday Massacre",
            "title": "Red Stars",
            "releasedate": "2007",
            "description": "Red Stars by Birthday Massacre",
            "lyrics": "It's my red star (steal it) It's my red star (cant let go) It's my red star (conceal it) It's my red star Oh, no"
        },
        {
            "id": 1,
            "artistId": 0,
            "albumId": 0,
            "albumName": "Walking with Strangers",
            "artistName": "Birthday Massacre",
            "title": "Looking Glass",
            "release date": "2007",
            "description": "Looking Glass by Birthday Massacre",
            "lyrics": "It's a glass cage so I can't pretend You hide beneath the physical I see it coming but I can't defend You cut so deep, my belief is gone My belief is gone, my belief is"        }
    ])
    return (
        <div class="song-listing">
            {songs.map((song) => {
                return (
                    <SongCard
                        key={song.id}
                        song={song} />
                )
            })}
        </div>
    )
}

export default SongListing
