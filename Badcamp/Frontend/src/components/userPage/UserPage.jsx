import CardContainer from './CardContainer';
import { useState, useEffect } from 'react';
import './UserPage.css';
import { useParams } from 'react-router-dom';
import Unauthorized from '../Unauthorized';
import EditUser from './EditUser';

const UserPage = () => {

    const { id } = useParams();
    const user = JSON.parse(localStorage.getItem('user'));
    const apiUrl = "https://localhost:7151/GetUsers";
    const [items, setItems] = useState([]);
    const [fetchError, setFetchError] = useState(null);
    const [state, setState] = useState(null);

    useEffect(() => {
        const fetchItems = async () => {
            try {
                const response = await fetch(apiUrl);
                if (!response.ok) throw Error('Did not receive expected data!');
                const listItems = await response.json();
                setItems(listItems);
            } catch (err) {
                setFetchError(err.message);
            }
        }

        fetchItems();

    }, []);

    return (
        !state ? (user && user.userId === id
        ?<div className="UserPage">
            <h1>My profile</h1>
            {items.filter(items => (items.id).toString() === id).map(user => (
                <CardContainer
                    key={user.id}
                    user={user}
                    setState={setState}
                />
            ))}
        </div>
        : <Unauthorized/>)
        : <>{items.filter(items => (items.id).toString() === id).map(user => (
            <EditUser
                key={user.id}
                userUpdate={user}
                setState={setState}
            />
        ))} 
        </>
        
    );
}

export default UserPage;