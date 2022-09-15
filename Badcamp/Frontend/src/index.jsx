import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import './index.css';
import App from './App';
import Home from './components/Home';

import ArtistListing from './components/artistListing/ArtistListing';
import ArtistPage from './components/artistPage/ArtistPage';
import EventPage from './components/eventComponents/EventPage';
import UserPage from './components/userPage/UserPage';
import SongListing from './components/songComponents/SongListing';
import Login from './components/Login/Login';
import Register from './components/Register/Registration';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<App />}>
          <Route index element={<Home />}></Route>
          <Route path='SongListing' element={<SongListing />}></Route>
          <Route exact path='/events' element={<EventPage />}></Route>
          <Route exact path='/artistpage' element={<ArtistPage artistId={1}/>}></Route>
          <Route path='ArtistListing' element={<ArtistListing />}></Route>
           <Route path="user">
              <Route path=":id" element={<UserPage/>} />
          </Route>
          <Route path="login" element={<Login />} />
          <Route path="register" element={<Register />} />
        </Route>
      </Routes>
    </BrowserRouter>
  </React.StrictMode>
);


