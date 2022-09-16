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
    const [regError, setRegError] = useState(null);
    const [fetchError, setFetchError] = useState(null);
    const [username, setUsername] = useState(null);

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


    const addUser = async (username, password, dateOfBirth, fullName) => {
        const id = users.length ? users[users.length - 1].id + 1 : 1;
        const newUser = { id, username, password, dateOfBirth, fullName };
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
        var { newUsername, newPassword, newDateOfBirth, newFullName, newPassword2 } = document.forms[0];

        var existingUsername = users.find((user) => user.username === newUsername.value);

        if (existingUsername) {
            setRegError("Username already exists, please try again!");
            return;

        }

        if (newPassword.value !== newPassword2.value) {
            setRegError("Passwords does not match, please try again!");
            return;
        }
        

        addUser(newUsername.value, newPassword.value, newDateOfBirth.value, newFullName.value);
    }

    return (
        <div className="Register">
            <h1>Registration</h1><br />
            <RegistrationForm
                handleSubmit={handleSubmit}
                regError={regError}
            //{/*errorMessage={error}*/}            />

        </div>
    );
}


export default Registration;