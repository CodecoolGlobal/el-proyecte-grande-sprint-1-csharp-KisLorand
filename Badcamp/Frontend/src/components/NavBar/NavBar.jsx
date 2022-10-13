import { Link } from 'react-router-dom';
import './NavBar.css';
import { useContext } from 'react';
import AuthContext from '../../contexts/AuthProvider';
import { FaUser } from 'react-icons/fa';

const NavBar = () => {

    const storedUser = JSON.parse(localStorage.getItem('user'));
    const { setAuth } = useContext(AuthContext);   

    const handleLogout = () => {
        localStorage.removeItem("user");
        setAuth(null);
    } 

    return (
        storedUser 
        ?
        <nav className="Nav">
            <img className="logo" src="./badcamp_logo2.png"></img>
            <ul>
                <li><Link to="/SongListing">Home</Link></li>
                <li><Link to="/ArtistListing">Artists</Link></li>
                <li><Link to={`profile/${storedUser.userId}`}>Profile</Link></li> 
                <li><Link to={`artistpage/edit`}>MyArtistPage</Link></li>
                <li><Link to="events">Events</Link></li>
                <li><Link to="/" onClick={handleLogout}>Logout</Link></li>
                <span id='logged-in'><FaUser style={{fontSize: "25px", marginRight: "8px"}}/>  {storedUser.user}</span>
            </ul>
        </nav>
        : 
        <nav className="Nav">
        <img className="logo" src="./badcamp_logo2.png"></img>
        <ul>
            <li><Link to="/">Home</Link></li>
            <li><Link to="/ArtistListing">Artists</Link></li>
            <li><Link to="events">Events</Link></li>
            <li><Link to="login">Login</Link></li> 
        </ul>
    </nav>
    );
}

export default NavBar;
