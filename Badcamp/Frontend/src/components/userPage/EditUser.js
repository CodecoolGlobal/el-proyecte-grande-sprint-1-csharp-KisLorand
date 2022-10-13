import React from 'react';
import { useState, useEffect, useContext } from 'react';
import { useParams } from 'react-router-dom';
import Unauthorized from '../Unauthorized';
import '../Login/Login.css';
import axios from '../../requests/axios';
import { useNavigate } from 'react-router-dom';
import AuthContext from '../../contexts/AuthProvider';

const EditUser = ({ userUpdate, setState }) => {
    const { id } = useParams();
    const user = JSON.parse(localStorage.getItem('user'));
    const [newUserName, setNewUserName] = useState(userUpdate.username);
    const [newFullName, setNewFullName] = useState(userUpdate.fullName);
    const [newBirthDate, setNewBirthDate] = useState(userUpdate.dateOfBirth);
    const [newPwd, setNewPwd] = useState(userUpdate.password);
    const [errMsg, setErrMsg] = useState('');   
    const UPDATE_USER_URL = `/UpdateUser/${user.user}`;
    const redirect = useNavigate();
    const { setAuth } = useContext(AuthContext);   

    useEffect(() => {
        setErrMsg('');
    }, [newUserName, newFullName, newBirthDate, newPwd]);

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            var data = null;
            if (user.user === newUserName)
            {
                data = { password: newPwd, dateOfBirth: newBirthDate, fullName: newFullName }
            }
            data = { username: newUserName, password: newPwd, dateOfBirth: newBirthDate, fullName: newFullName }

            await axios.put(UPDATE_USER_URL,
                JSON.stringify(data),
                {
                    headers: { 'Content-Type': 'application/json'}
                }
            );
            setNewUserName('');
            setNewFullName('');
            setNewBirthDate('');
            setNewPwd('');
            
            if (user.user !== newUserName) {
                localStorage.removeItem("user");
                setAuth(null);
                setState(null);
                redirect('/login');
            } else {
                // window.location.reload(false);
                setState(null);
                redirect(`/profile/${id}/updating`);
                
            }

            
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
        user && user.userId === id ? 
        <div className="InputForm">
        <section>
        <p className={errMsg ? "errmsg" : "offscreen"}>
            {errMsg}
        </p>

        <h1>Update Info</h1>

        <form onSubmit={handleSubmit}>
            <span style={{color: 'red'}}>Changing username requires relogging!</span>
            <label htmlFor="username">Username</label>
            <input 
                type="text" 
                id="username" 
                autoComplete='off'
                onChange={(e) => setNewUserName(e.target.value)}
                value={newUserName}
            />

            <label htmlFor="fullname">FullName</label>
            <input 
                type="text" 
                id="fullname" 
                onChange={(e) => setNewFullName(e.target.value)}
                value={newFullName}
            />

            <label htmlFor="birthdate">Date of birth</label>
            <input 
                type="date" 
                id="birthdate" 
                onChange={(e) => setNewBirthDate(e.target.value)}
                value={newBirthDate}
            />

            <label htmlFor="password1">Password</label>
            <input 
                type="password" 
                id="password1" 
                onChange={(e) => setNewPwd(e.target.value)}
                value={newPwd}
            />

            <button>Update</button>   
            <button onClick={() => setState(null)}>Cancel</button>   

        </form>      
        </section> 
        </div>
        : <Unauthorized />
    )
}

export default EditUser