import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import './index.css';
import App from './App';
import Home from './components/Home';
import ArtistListing from './components/artistListing/ArtistListing';
import ArtistPage from './components/artistPage/ArtistPage';
import EventPage from './components/eventComponents/EventPage';
import SongListing from './components/songComponents/SongListing';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<App />}>
          <Route index element={<SongListing />}></Route>
          <Route exact path='/events' element={<EventPage />}></Route>
          <Route exact path='/artistpage' element={<ArtistPage artistId={1}/>}></Route>
          <Route path='ArtistListing' element={<ArtistListing />}></Route>
        </Route>
      </Routes>
    </BrowserRouter>
  </React.StrictMode>
);


