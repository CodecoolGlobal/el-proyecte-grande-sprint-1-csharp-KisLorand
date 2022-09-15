import { Link } from 'react-router-dom';
import './NavBar.css';

const NavBar = () => {

    return (
        <nav className="Nav">
            <img className="logo" src="./badcamp_logo2.png"></img>
            <ul>
                <li><Link to="/">Home</Link></li>
                <li><Link to="login">Login</Link></li>
                <li><Link to="/ArtistListing">Artists</Link></li>
                <li><Link to="user/1">Users</Link></li>
                <li><Link to="register">Register</Link></li>
                <li><Link to="">Logout</Link></li>
                <li><Link to="events">Events</Link></li>
            </ul>
        </nav>
    );
}

export default NavBar;
