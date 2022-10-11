import './Login.css';
import LoginForm from './LoginForm';
import React from 'react';
import { useState, useEffect, useContext } from 'react';
import { useNavigate } from 'react-router-dom';
import { UserContext } from '../../userContext/UserContext';


const Login = () => {

    const { setUserId } = useContext(UserContext);

    const [error, setError] = useState(null);
    const redirect = useNavigate();

    const apiUrl = "http://localhost:3000/users";
    const [users, setUsers] = useState([]);

    useEffect(() => {
        const fetchItems = async () => {
            try {
                const response = await fetch(apiUrl);
                if (!response.ok) throw Error('Did not receive expected data!');
                const listUsers = await response.json();
                setUsers(listUsers);
            } catch (err) {
                console.log(err.message);
            } 
        }

        fetchItems();
        

    }, []);


const handleSubmit = (e) => {
    e.preventDefault();

    var { username, password } = document.forms[0];
    var userData = users.find((user) => user.username === username.value);

    if (userData) {
        if (userData.password !== password.value) {
            setError('Invalid password');
        } else {
            setUserId(userData.id);
            redirect('/');
        }
    } else {
        setError('Invalid username');
    }

}

    return (
        <div className="Login">
            <h1>Login</h1><br /><br />
            <LoginForm
                handleSubmit={handleSubmit}
                errorMessage={error}
            />
        </div>
    );
}

export default Login;

