import './Login.css';
import LoginForm from './LoginForm';
import React from 'react';
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';


const Login = () => {

    const [isLoggedIn, setIsLoggedIn] = useState(false);
    const [error, setError] = useState(null);
    const redirect = useNavigate();

    const userDatabase = [
        {
            id: 1,
            username: "test",
            password: "test"
        },
        {
            id: 2,
            username: "someone",
            password: "pw"
        },
        {
            id: 3,
            username: "someone else",
            password: "123"
        }
    ];

const handleSubmit = (e) => {
    e.preventDefault();

    var { username, password } = document.forms[0];
    var userData = userDatabase.find((user) => user.username === username.value);

    if (userData) {
        if (userData.password !== password.value) {
            setError('Invalid password');
        } else {
            setIsLoggedIn(true);
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

