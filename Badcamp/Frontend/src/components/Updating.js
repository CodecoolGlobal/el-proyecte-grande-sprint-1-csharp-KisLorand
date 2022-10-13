import React from 'react';
import { useParams } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';

const Updating = () => {
    const { id } = useParams();
    const redirect = useNavigate();
    setTimeout(()=> {redirect(`/profile/${id}`);}, 2000);   
    return (
        <div className='update'>
        <h1>UPDATING USER DATA</h1>
        </div>
    )
}

export default Updating