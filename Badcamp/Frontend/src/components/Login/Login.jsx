import './Login.css';
import LoginForm from './LoginForm';
import React from 'react';
import { useState, useEffect, useContext, useRef } from 'react';
import { useNavigate, useLocation } from 'react-router-dom';
import AuthContext from '../../contexts/AuthProvider';
import jwt_decode from "jwt-decode";
import axios from '../../requests/axios';
const LOGIN_URL = '/login';


const Login = () => {
    const { setAuth } = useContext(AuthContext);

    const redirect = useNavigate();
    const location = useLocation();
    const from = location.state?.from?.pathname || "/";

    const userRef = useRef();
    const errRef = useRef();

    const [user, setUser] = useState('');
    const [pwd, setPwd] = useState('');
    const [errMsg, setErrMsg] = useState('');   
    
    
    useEffect(() => {
        userRef.current.focus();
    }, []);

    useEffect(() => {
        setErrMsg('');
    }, [user, pwd]);

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            const response = await axios.post(LOGIN_URL,
                JSON.stringify({Username: user, Password: pwd}),
                {
                    headers: { 'Content-Type': 'application/json'},
                    withCredentials: true
                }
            );

            
            const accessToken = response?.data.value;
            const decoded = jwt_decode(accessToken);
            const userId = (decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/primarysid']);         

            const userData = { user, userId, accessToken };
            localStorage.setItem("user", JSON.stringify(userData));
            setAuth(userData);
            setUser('');
            setPwd('');
            redirect(from, { replace: true });
        } catch (err) {
            console.log(err);
            if (!err.response) {
                setErrMsg('No Server Response');
            } else if (err.response?.status === 400) {
                setErrMsg('Wrong Username or Password');
            } else if (err.response?.status === 401) {
                setErrMsg('Unauthorized');
            } else if (err.response?.status === 404) {
                setErrMsg('User does not exist');
            } else {
                setErrMsg('Login Failed');
            }
            errRef.current.focus();
        }
    }    

    return (
        <div className="InputForm">
            <LoginForm
                user={user}
                setUser={setUser}
                userRef={userRef}
                pwd={pwd}
                setPwd={setPwd}
                errRef={errRef}
                errMsg={errMsg}
                handleSubmit={handleSubmit}
            />
        </div>
    );
}

export default Login;

