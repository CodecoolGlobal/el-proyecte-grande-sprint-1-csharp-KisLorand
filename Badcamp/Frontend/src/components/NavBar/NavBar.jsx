import { Link } from 'react-router-dom';
import './NavBar.css';

const NavBar = () => {

    return (
        <nav className="Nav">
            <p className="logo">LOGO</p>
            <ul>
                <li><Link to="/">Home</Link></li>
                <li><Link to="login">Login</Link></li>
                <li><Link to="/">Artists</Link></li>
                <li><Link to="user/1">Users</Link></li>
                <li><Link to="/">Register</Link></li>
                <li><Link to="register">Logout</Link></li>
                <li><Link to="events">Events</Link></li>
            </ul>
        </nav>
    );
}

export default NavBar;