import './Register.css';
import RegistrationForm from './RegistrationForm';
import React from 'react';
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';

const Registration = () => {

    const [error, setError] = useState(null);
    const redirect = useNavigate();

    const userData = [
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

    const addUser = (username, password) => {
        const id = userData.length ? userData[userData.length - 1].id + 1 : 1;
        const newUser = { id, username, password };
        userData.push(newUser);
        console.log(userData);
        redirect('/');
    }

    const handleSubmit = (e) => {
        e.preventDefault();
        var { newUsername, newPassword } = document.forms[0];
        addUser(newUsername.value, newPassword.value);
    }

    return (
        <div className="Register">
            <h1>Registration</h1><br /><br />
            <RegistrationForm
                handleSubmit={handleSubmit}
            //{/*errorMessage={error}*/}            />

        </div>
    );
}


export default Registration;