import CardContainer from './CardContainer';
import { useState, useEffect } from 'react';
import './UserPage.css';

const UserPage = () => {

    const apiUrl = "http://localhost:3500/users";
    const [items, setItems] = useState([]);
    const [fetchError, setFetchError] = useState(null);

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
        <div className="UserPage">
            {items.filter(items => items.id === 1).map(user => (
                <CardContainer
                    key={user.id}
                    user={user}
                />
            ))}
        </div>
    );
}

export default UserPage;