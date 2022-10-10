import { Link } from 'react-router-dom';
import './NavBar.css';
import { useContext } from 'react';
import { UserContext } from '../../userContext/UserContext';

const NavBar = () => {
    const { userId, setUserId } = useContext(UserContext);

    return (
        <nav className="Nav">
            <img className="logo" src="./badcamp_logo2.png"></img>
            <ul>
                <li><Link to="/">Home</Link></li>
                <li><Link to="/ArtistListing">Artists</Link></li>
                {userId ? <li><Link to={`profile/${userId}`}>Profile</Link></li> : null}
                <li><Link to="register">Register</Link></li>
                <li><Link to="events">Events</Link></li>
                {!userId ? <li><Link to="login">Login</Link></li> 
                : <li><Link to="/" onClick={() => setUserId(null)}>Logout</Link></li> }
            </ul>
        </nav>
    );
}

export default NavBar;
