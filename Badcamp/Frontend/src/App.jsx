import 'bootstrap/dist/css/bootstrap.min.css';
import Layout from './components/Layout';
import { UserContext } from './userContext/UserContext';
import {useState} from 'react';

function App() {
    const [userId, setUserId] = useState(null);

    return (
        <div className="App">
            <UserContext.Provider value={{userId, setUserId}}>
                <Layout />
            </UserContext.Provider>
        </div>
    );
}

export default App;