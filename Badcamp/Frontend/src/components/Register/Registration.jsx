import '../Login/Login.css';
import RegistrationForm from './RegistrationForm';
import React from 'react';
import { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from '../../requests/axios';
const REGISTER_URL = '/RegisterUser';

const Registration = () => {
    const redirect = useNavigate();
    const [newUserName, setNewUserName] = useState('');
    const [fullName, setFullName] = useState('');
    const [birthDate, setBirthDate] = useState('');
    const [pwd1, setPwd1] = useState('');
    const [pwd2, setPwd2] = useState('');
    const [errMsg, setErrMsg] = useState('');   

    useEffect(() => {
        setErrMsg('');
    }, [newUserName, fullName, birthDate, pwd1, pwd2]);

    const handleSubmit = async (e) => {
        e.preventDefault();

        if(pwd1 !== pwd2){
            setErrMsg('Passwords do not match!');
        }
        
        try {
            await axios.post(REGISTER_URL,
                JSON.stringify({ newUser: { username: newUserName, password: pwd1, dateOfBirth: birthDate, fullName: fullName } }),
                {
                    headers: { 'Content-Type': 'application/json'}
                }
            );
            setNewUserName('');
            setFullName('');
            setBirthDate('');
            setPwd1('');
            setPwd2('');
            redirect('/login');
        } catch (err) {
            if (!err.response) {
                setErrMsg('No Server Response');
            } else if (err.response?.status === 400) {
                setErrMsg('User already exists!');
            } else {
                setErrMsg('Register Failed');
            }
        }
    }

    return (
        <div className="InputForm">
            <RegistrationForm
                newUserName={newUserName}
                setNewUserName={setNewUserName}
                fullName={fullName}
                setFullName={setFullName}
                birthDate={birthDate}
                setBirthDate={setBirthDate}
                pwd1={pwd1}
                setPwd1={setPwd1}
                pwd2={pwd2}
                setPwd2={setPwd2}
                errMsg={errMsg}
                handleSubmit={handleSubmit}
            />
        </div>
    );
}

export default Registration;