import 'bootstrap/dist/css/bootstrap.min.css';
import Layout from './components/Layout';
import { Routes, Route } from 'react-router-dom';
import ArtistListing from './components/artistListing/ArtistListing';
import ArtistPage from './components/artistPage/ArtistPage';
import EventPage from './components/eventComponents/EventPage';
import UserPage from './components/userPage/UserPage';
import SongListing from './components/songComponents/SongListing';
import Login from './components/Login/Login';
import Register from './components/Register/Registration';
import RequireAuth from './components/RequireAuth';
import Unauthorized from './components/Unauthorized';
import EditUser from './components/userPage/EditUser';
import Updating from './components/Updating';

function App() {
    return (
        <Routes>
            <Route path="/" element={<Layout />}>

                {/* public routes */} 
                <Route path="unauthorized" element={<Unauthorized />} /> 
                <Route index element={<SongListing/>}></Route>
                <Route path='SongListing' element={<SongListing />}></Route>
                <Route exact path='/events' element={<EventPage />}></Route>
                <Route exact path='/artistpage'>
                    <Route path=":id" element={<ArtistPage/>} />
                </Route>
                <Route path='ArtistListing' element={<ArtistListing />}></Route>
                <Route path="login" element={<Login />} />
                <Route path="register" element={<Register />} />
                <Route path="artistpage">
                   <Route path=":id" element={<ArtistPage artistId={1}/>} />
                </Route>

                {/* protected routes */} 
                <Route element={<RequireAuth />}>     
                    <Route path="profile">
                        <Route path=":id" element={<UserPage/>} />
                        <Route path=":id/edit" element={<EditUser />}/>
                        <Route path=":id/updating" element={<Updating />}/>
                    </Route>
                    <Route path="artistpage/edit" element={<ArtistPage/>} />
                </Route> 
                
            </Route>
        </Routes>
    );
}

export default App;