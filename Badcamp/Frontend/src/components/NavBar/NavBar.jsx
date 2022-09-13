import { Link } from 'react-router-dom';
import './NavBar.css';

const NavBar = () => {

    return (
        <nav className="Nav">
            <img className="logo" src="./badcamp_logo.png"></img>
            <ul>
                <li><Link to="/">Home</Link></li>
                <li><Link to="/">Login</Link></li>
                <li><Link to="/">Artists</Link></li>
                <li><Link to="/">Users</Link></li>
                <li><Link to="/">Register</Link></li>
                <li><Link to="/">Logout</Link></li>
            </ul>
        </nav>
    );
}

export default NavBar;