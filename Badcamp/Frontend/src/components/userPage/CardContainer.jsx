import CardItem from './CardItem';
import PlaylistCard from './PlaylistCard';
import Card from 'react-bootstrap/Card';


const CardContainer = ({ user, setState }) => {

    return (
        <div>
            <Card style={{ width: '18rem', border: 'solid 2px black' }} bg="light" className="CardContainer">
                <CardItem
                    user={user}
                    setState={setState}
                />
            </Card>
            <Card style={{ width: '18rem', border: 'solid 2px black' }} bg="dark" text="white" className="CardContainer">
                <PlaylistCard
                    user={user}
                />
            </Card>
        </div>
    );
}

export default CardContainer;