import './Register.css';
import RegistrationForm from './RegistrationForm';
import React from 'react';
import { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import apiRequest from './apiRequest';


const Registration = () => {

    const [error, setError] = useState(null);
    const redirect = useNavigate();

    const apiUrl = "http://localhost:3000/users";
    const [users, setUsers] = useState([]);
    const [fetchError, setFetchError] = useState(null);

    useEffect(() => {
        const fetchItems = async () => {
            try {
                const response = await fetch(apiUrl);
                if (!response.ok) throw Error('Did not receive expected data!');
                const listUsers = await response.json();
                setUsers(listUsers);
            } catch (err) {
                setFetchError(err.message);
            }
        }

        fetchItems();


    }, []);


    const addUser = async (username, password) => {
        const id = users.length ? users[users.length - 1].id + 1 : 1;
        const newUser = { id, username, password };
        const userList = [...users, newUser];
        setUsers(userList);

        const postOptions = {
            method: 'POST',
            headers: {
                'Content-type': 'application/json'
            },
            body: JSON.stringify(newUser)
        }

        const result = await apiRequest(apiUrl, postOptions);
        if (result) setFetchError(result);

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