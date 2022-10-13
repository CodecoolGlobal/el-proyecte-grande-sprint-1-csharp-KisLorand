import { Link } from 'react-router-dom';
import './NavBar.css';
import { useContext } from 'react';
import AuthContext from '../../contexts/AuthProvider';

const NavBar = () => {
    const user = JSON.parse(localStorage.getItem('user'));
    const { setAuth } = useContext(AuthContext);

    const handleLogout = () => {
        localStorage.removeItem("user");
        setAuth(null);
    } 

    return (
        <nav className="Nav">
            <img className="logo" src="./badcamp_logo2.png"></img>
            <ul>
                <li><Link to="/">Home</Link></li>
                <li><Link to="/ArtistListing">Artists</Link></li>
                {user ? <li><Link to={`profile/${user.userId}`}>Profile</Link></li> : null}
                {user ? <li><Link to={`artistpage/edit`}>MyArtistPage</Link></li> : null}
                <li><Link to="register">Register</Link></li>
                <li><Link to="events">Events</Link></li>
                {!user ? <li><Link to="login">Login</Link></li> 
                : 
                <>
                <li><Link to="/" onClick={handleLogout}>Logout</Link></li>
                <span id='logged-in'>{user.user}</span>
                </>}
            </ul>
        </nav>
    );
}

export default NavBar;
