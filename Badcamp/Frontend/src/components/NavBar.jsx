import { Link } from 'react-router-dom';

const NavBar = () => {

    return (
        <nav className="NavBar">
            <p className="logo">LOGO</p>
            <ul>
                <li><Link to="/">Home</Link></li>
                <li><Link>Login</Link></li>
                <li><Link>Artists</Link></li>
                <li><Link>Users</Link></li>
                <li><Link>Register</Link></li>
                <li><Link>Logout</Link></li>
            </ul>
        </nav>
    );
}

export default NavBar;