import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import './index.css';
import App from './App';
import Home from './components/Home';
import ArtistPage from './components/artistPage/ArtistPage';
import EventPage from './components/eventComponents/EventPage';
import UserPage from './components/userPage/UserPage';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    <React.StrictMode>
        <BrowserRouter>
            <Routes>
                <Route path='/' element={<App />}>
                    <Route index element={<Home />}></Route>
                    <Route exact path='/events' element={<EventPage />}></Route>
                    <Route path="user">
                        <Route path=":id" element={<UserPage
                        />} />
                    </Route>
                </Route>
            </Routes>
        </BrowserRouter>
    </React.StrictMode>
);


